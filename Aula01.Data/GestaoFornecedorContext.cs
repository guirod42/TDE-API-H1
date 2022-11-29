using Aula01.Data.Mappings;
using Aula01.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aula01.Data
{
    public class GestaoFornecedorContext : DbContext
    {
        public GestaoFornecedorContext(DbContextOptions<GestaoFornecedorContext> options) : base(options)
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedorMap());
        }
    }
}
