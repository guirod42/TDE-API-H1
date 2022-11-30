using Aula01.Model;

namespace Aula01.Services
{
    public class ProdutoService : IProdutoService
    {
        public Task Adicionar(ProdutoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(ProdutoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel ObterProdutoId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> ObterProdutoName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
