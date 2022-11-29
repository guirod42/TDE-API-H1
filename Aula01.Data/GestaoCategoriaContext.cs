using Aula01.Data.Mappings;
using Aula01.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Data
{
    public class GestaoCategoriaContext : DbContext
    {
        public GestaoCategoriaContext(DbContextOptions<GestaoCategoriaContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }
    }
}
