using Aula01.Model;

namespace Aula01.Services
{
    public interface IFornecedorService
    {
        public Task Cadastrar(FornecedorViewModel fornecedor);
        public void Atualizar(FornecedorViewModel fornecedor);
        public void Ativar(int id);
        public void Desativar(int id);
        public void Remover(int id);
        public FornecedorViewModel ObterFornecedorId(int id);
        public IEnumerable<FornecedorViewModel> ObterTodos();
    }
}
