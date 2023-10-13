using Microsoft.EntityFrameworkCore;
using NTT_API.Data;
using NTT_API.Models;

namespace NTT_API.Repository
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly EstabecimentoDBContex _dbContext;

        public EstabelecimentoRepository(EstabecimentoDBContex estabecimentoDBContex)
        {
            _dbContext = estabecimentoDBContex;
        }
        public async Task<EstabelecimentoModel> AdicionarEstab(EstabelecimentoModel estabelecimento)
        {
            _dbContext.Estabelecimento.AddAsync(estabelecimento);
            _dbContext.SaveChangesAsync();
            return estabelecimento;
        }

        public async Task<EstabelecimentoModel> Atualizar(EstabelecimentoModel estabelecimento, int id)
        {
            EstabelecimentoModel estabelecimentoporId = await ListarEstabid(id);
            if (estabelecimentoporId == null)
            {
                throw new Exception($"Usuario não encontrado, com o id: {id}");
            }

            estabelecimentoporId.CEP = estabelecimento.CEP;
            estabelecimentoporId.Logradouro = estabelecimento.Logradouro;
            estabelecimentoporId.Bairro = estabelecimento.Bairro;
            estabelecimentoporId.Localidade = estabelecimento.Localidade;
            estabelecimentoporId.UF = estabelecimento.UF;
            estabelecimentoporId.Numero = estabelecimento.Numero;
            estabelecimentoporId.Complemento = estabelecimento.Complemento;

            _dbContext.Estabelecimento.Update(estabelecimentoporId);
            _dbContext.SaveChangesAsync();
            return estabelecimentoporId;

        }                       

        public async Task<List<EstabelecimentoModel>> ListarEstab()
        {
           return await _dbContext.Estabelecimento.ToListAsync();
        }

        public async Task<EstabelecimentoModel> ListarEstabid(int id)
        {
            return await _dbContext.Estabelecimento.FirstOrDefaultAsync(x => x.ID_Tarefa == id);
        }
    }
}
