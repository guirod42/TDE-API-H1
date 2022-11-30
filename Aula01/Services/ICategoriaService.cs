

using Aula01.Model;

namespace Aula01.Services
{
    public interface ICategoriaService
    {
        public void Cadastrar(CategoriaViewModel categoria);
        public void Atualizar(int id, string nome);
        public void Ativar(int id);
        public void Desativar(int id);
        public void Remover(int id);
        public CategoriaViewModel ObterCategoriaId(int id);
        public IEnumerable<CategoriaViewModel> ObterTodos();
    }
}
