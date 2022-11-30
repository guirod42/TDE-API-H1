

using Aula01.Model;

namespace Aula01.Services
{
    public interface ICategoriaService
    {
        public void Cadastrar(CategoriaViewModel categoria);
        public void Atualizar(CategoriaViewModel categoria);
        public void Ativar(CategoriaViewModel categoria);
        public void Desativar(CategoriaViewModel categoria);
        public void Remover(int id);
        public CategoriaViewModel ObterCategoriaId(int id);
        public IEnumerable<CategoriaViewModel> ObterTodos();
    }
}
