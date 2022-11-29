﻿using Aula01.Data.Mappings;
using Aula01.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aula01.Data
{
	public class GestaoProdutoContext : DbContext
    {
        public GestaoProdutoContext(DbContextOptions<GestaoProdutoContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }
    }
}
