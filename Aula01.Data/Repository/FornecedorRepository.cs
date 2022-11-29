using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Data.Repository
{
	public class FornecedorRepository : IFornecedorRepository //operações > Interfaces
    { 
        private readonly GestaoProdutoContext _context;

		public FornecedorRepository(GestaoProdutoContext context)
		{
			_context = context;
		}
		public void Cadastrar(Fornecedor fornecedor)
		{
            _context.Fornecedor.Add(fornecedor);
            Gravar();
        }

		public void Atualizar(Fornecedor fornecedor)
		{
            _context.Fornecedor.Update(fornecedor);
            Gravar();
		}

        public void Ativar(Fornecedor fornecedor)
        {
            fornecedor.On();
            _context.Fornecedor.Update(fornecedor);
            Gravar();
        }

        public void Desativar(Fornecedor fornecedor)
        {
            fornecedor.Off();
            _context.Fornecedor.Update(fornecedor);
            Gravar();
        }

        public void Remover(int id)
        {
            _context.Remove(id);
        }

		public Fornecedor ObterFornecedorId(int id)
		{
            return _context.Fornecedor.Where(p => p.Id == id).FirstOrDefault();
        }

		public IEnumerable<Fornecedor> ObterTodos()
		{
            return _context.Fornecedor.ToList();
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
