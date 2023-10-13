using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT_API.Models;

namespace NTT_API.Data.Map
{
    public class EstabelecimentoMap : IEntityTypeConfiguration<EstabelecimentoModel>
    {
        public void Configure(EntityTypeBuilder<EstabelecimentoModel> builder)
        {
            builder.HasKey(x => x.ID_Tarefa);
            builder.Property(x => x.Nome_Tarefa).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Bairro).HasMaxLength(25);
            builder.Property(x => x.UF).HasMaxLength(2);
            builder.Property(x => x.Complemento);
            builder.Property(x => x.Logradouro);
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Localidade);
            builder.Property(x => x.Telefone_Tarefa).IsRequired().HasMaxLength(12);
            builder.Property(x => x.Dt_Cadastro_Tarefa).IsRequired();
            builder.Property(x => x.Descricao_foto);
            builder.Property(x => x.Nome_foto);
            builder.Property(x => x.Img_Foto).HasColumnType("IMAGE").HasConversion(v => v, v => v);
        }

    }
}
