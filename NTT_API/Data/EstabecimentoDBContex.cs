using Microsoft.EntityFrameworkCore;
using NTT_API.Data.Map;
using NTT_API.Models;

namespace NTT_API.Data
{
    public class EstabecimentoDBContex : DbContext
    {
        public EstabecimentoDBContex(DbContextOptions<EstabecimentoDBContex> options):
             base(options)
        {

        }

        public DbSet<EstabelecimentoModel> Estabelecimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstabelecimentoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
