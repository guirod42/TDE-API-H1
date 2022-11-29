using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain.Interfaces
{
	public interface IFornecedorRepository
	{
		public void Cadastrar(Fornecedor fornecedor);
		public void Atualizar(Fornecedor fornecedor);
		public void Ativar(Fornecedor fornecedor);
		public void Desativar(Fornecedor fornecedor);
        public void Remover(int id);
		public Fornecedor ObterFornecedorId(int id);
        public IEnumerable<Fornecedor> ObterTodos();
	}
}
