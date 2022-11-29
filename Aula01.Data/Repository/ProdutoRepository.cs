using Aula01.Domain;
using Aula01.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Data.Repository
{
	public class ProdutoRepository : IProdutoRepository
	{
		private readonly GestaoProdutoContext _context;

		public ProdutoRepository(GestaoProdutoContext context)
		{
			_context = context;
		}

		public void Cadastrar(Produto produto)
		{
			_context.Produto.Add(produto);
			Gravar();
		} 

		public IEnumerable<Produto> ObterTodos()
		{
			return _context.Produto.ToList();
		}

		public void Atualizar(Produto produto)
		{
			_context.Produto.Update(produto);
			Gravar();
		}

		public Produto ObterProdutoId(int id)
		{
			return _context.Produto.Where(p => p.Id == id).FirstOrDefault();
		}

		public IEnumerable<Produto> ObterProdutoName(string name)
		{
			return _context.Produto.Where(p => p.Nome == name);
		}
		
		public void Remover(int id)
		{
			_context.Remove(id);
		}

        public void Ativar(Produto produto)
        {
            produto.On();
			_context.Produto.Update(produto);
			Gravar();
        }

        public void Desativar(Produto produto)
        {
            produto.Off();
            _context.Produto.Update(produto);
            Gravar();
        }





		private void Gravar()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
    }
}
