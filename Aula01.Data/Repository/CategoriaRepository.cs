using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly GestaoProdutoContext _context;

        public CategoriaRepository(GestaoProdutoContext context)
        {
            _context = context;
        }

        public void Cadastrar(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            Gravar();
        }

        public void Atualizar(Categoria categoria)
        {
            _context.Categoria.Update(categoria);
            Gravar();
        }

        public void Ativar(Categoria categoria)
        {
            categoria.On();
            _context.Categoria.Update(categoria);
            Gravar();
        }

        public void Desativar(Categoria categoria)
        {
            categoria.Off();
            _context.Categoria.Update(categoria);
            Gravar();
        }

        public void Remover(int id)
        {
            _context.Remove(id);
        }

        public Categoria ObterCategoriaId(int id)
        {
            return _context.Categoria.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            //var x = _context.Categoria.ToList();
            return _context.Categoria.ToList();
        }




        private void Gravar()
        {
            _context.SaveChanges();
        }
    }
}
