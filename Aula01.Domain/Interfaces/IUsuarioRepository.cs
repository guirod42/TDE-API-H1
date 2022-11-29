using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario Autenticar(Usuario usuario);
        public void Cadastrar(Usuario usuario);
        public void Atualizar(Usuario usuario);
        public Usuario Localizar(string user);
        public void Ativar(Usuario usuario);
        public void Desativar(Usuario usuario);
    }
}
