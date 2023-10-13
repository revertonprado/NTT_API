using Microsoft.AspNetCore.Mvc;
using NTT_API.Models;
using NTT_API.Repository;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace NTT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabecimentoController : ControllerBase
    {
        public readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabecimentoController(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }




        // GET: api/<Class>
        [HttpGet]
        public async Task<ActionResult<List<EstabelecimentoModel>>> ListarEstab()
        {
            List<EstabelecimentoModel> estabelecimentos = await _estabelecimentoRepository.ListarEstab();
            return Ok(estabelecimentos);
        }

        // GET api/<Class>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstabelecimentoModel>> ListarEstabid(int id)
        {
            EstabelecimentoModel estabelecimentos = await _estabelecimentoRepository.ListarEstabid(id);
            return Ok(estabelecimentos);
        }

        // POST api/<Class>
        [HttpPost]
        public async Task<ActionResult<EstabelecimentoModel>> AdicionarEstab([FromForm] EstabelecimentoModel estabelecimentoModel, [FromForm] UploadFoto uploadFoto)
        {
            try
            {
                // Verifica se a extensão do arquivo é .png
                string[] allowedExtensions = { ".png" };
                var fileExtension = Path.GetExtension(uploadFoto.Foto.FileName);

                if (!allowedExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
                {
                    return BadRequest("A imagem deve ser do tipo PNG.");
                }


                using (var memoryStream = new MemoryStream())
                {
                    try
                    {
                        await uploadFoto.Foto.CopyToAsync(memoryStream);
                        var fotoBytes = memoryStream.ToArray();
                        estabelecimentoModel.Img_Foto = fotoBytes;

                        string nomeDaFoto = Path.GetFileName(uploadFoto.Foto.FileName);
                        estabelecimentoModel.Nome_foto = nomeDaFoto;


                    }
                    catch (Exception ex)
                    {
                        return BadRequest($"Erro ao realizar o upload da imagem: {ex.Message}");
                    }
                }

                var viaCEPResponse = await ConsultarViaCEP(estabelecimentoModel.CEP);

                if (viaCEPResponse != null)
                {
                    estabelecimentoModel.Localidade = viaCEPResponse.Localidade;
                    estabelecimentoModel.UF = viaCEPResponse.UF;
                    estabelecimentoModel.Bairro = viaCEPResponse.Bairro;
                    estabelecimentoModel.Logradouro = viaCEPResponse.Logradouro;
                    estabelecimentoModel.Complemento = viaCEPResponse.Complemento;
                }
                else
                {
                    // Lidar com CEP inválido ou não encontrado
                    return BadRequest($"Erro ao processar os dados: CEP Não encontrado");
                }

                if (!Regex.IsMatch(estabelecimentoModel.Telefone_Tarefa, @"^\d{2}-\d{9}$"))
                {
                    return BadRequest($"Erro ao processar os dados: Telefone em um formato inválido. Use o formato 11-111111111.");
                }

                EstabelecimentoModel estabelecimento = await _estabelecimentoRepository.AdicionarEstab(estabelecimentoModel);
                return Ok(estabelecimento);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro geral: {ex.Message}");
            }
        }

        // PUT api/<Class>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EstabelecimentoModel>> Atualizar([FromBody] EstabelecimentoModel estabelecimentoModel, int id)
        {
            estabelecimentoModel.ID_Tarefa = id;

            var viaCEPResponse = await ConsultarViaCEP(estabelecimentoModel.CEP);

            if (viaCEPResponse != null)
            {
                estabelecimentoModel.Localidade = viaCEPResponse.Localidade;
                estabelecimentoModel.UF = viaCEPResponse.UF;
                estabelecimentoModel.Bairro = viaCEPResponse.Bairro;
                estabelecimentoModel.Logradouro = viaCEPResponse.Logradouro;
                estabelecimentoModel.Complemento = viaCEPResponse.Complemento;
            }
            else
            {
                
                return BadRequest($"Erro ao processar os dados: CEP Não encontrado");
            }




            EstabelecimentoModel estabelecimento = await _estabelecimentoRepository.Atualizar(estabelecimentoModel, id);
            return Ok(estabelecimento);
        }

        // DELETE api/<Class>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async Task<CEPT> ConsultarViaCEP(string cep)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var viaCEPResponse = JsonConvert.DeserializeObject<CEPT>(content);
                      
                        return viaCEPResponse;
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                // Lide com exceções de solicitação HTTP, se necessário
                return null;
            }
        }

        
    }
}
