using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NTT_API.Models
{
    public class EstabelecimentoModel
    {
        public int ID_Tarefa { get; set; }

        public string Nome_Tarefa { get; set; }

        public string CEP { get; set; }
        
        public string Logradouro { get; set; } = "1";
        
        public string Bairro { get; set; } = "1";

        public string Localidade { get; set; } = "1";

        public string UF { get; set; } = "1";

        public int Numero { get; set; }

        public byte[] Img_Foto { get; set; } = new byte[0];
        public string Nome_foto { get; set; } = "1";
       
        public string Complemento { get; set; } = "1";

        public string Descricao_foto { get; set; } = "PNG";

        public DateTime Dt_Cadastro_Tarefa { get; set; } = DateTime.Now;

        public string Telefone_Tarefa {  get; set; }

    }

    public class UploadFoto
    {
        public IFormFile Foto { get; set; }

    }

    public class CEPT
    {
        
        public string CEP { get; set; }
        [BindNever]
        public string Logradouro { get; set; }
        [BindNever]
        public string Bairro { get; set; }
        [BindNever]
        public string Localidade { get; set; }
        [BindNever]
        public string UF { get; set; } 
        [BindNever]
        public string Complemento { get; set; } 

    }


}
