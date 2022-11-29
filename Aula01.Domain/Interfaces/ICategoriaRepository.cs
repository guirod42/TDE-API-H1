using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        public void Cadastrar(Categoria categoria);
        public void Atualizar(Categoria categoria);
        public void Ativar(Categoria categoria);
        public void Desativar(Categoria categoria);
        public void Remover(int id);
        public Categoria ObterCategoriaId(int id);
        public IEnumerable<Categoria> ObterTodos();
    }
}