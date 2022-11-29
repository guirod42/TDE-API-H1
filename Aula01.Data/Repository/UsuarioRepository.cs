using Aula01.Domain;
using Aula01.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GestaoProdutoContext _context;
        public UsuarioRepository(GestaoProdutoContext context)
        {
            _context = context;
        }

        public Usuario Autenticar(Usuario usuario)
        {
            return _context.Usuario.Where(p => p.UserName == usuario.UserName
                && p.Password == usuario.Password).FirstOrDefault();
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            Gravar();
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            Gravar();
        }

        public void Ativar(Usuario usuario)
        {
            usuario.On();
            _context.Usuario.Update(usuario);
            Gravar();
        }

        public void Desativar(Usuario usuario)
        {
            usuario.Off();
            _context.Usuario.Update(usuario);
            Gravar();
        }

        public Usuario Localizar(string user)
        {
            return _context.Usuario.Where(p => p.UserName == user).FirstOrDefault();
        }





        private void Gravar()
        {
            _context.SaveChanges();
        }
    }
}
