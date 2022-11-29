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
            
		    var buscaUsuario = _context.Usuario.Where(p => p.UserName == usuario.UserName 
                                                && p.Password == usuario.Password).FirstOrDefault();
            
            if (buscaUsuario != null) return new Usuario(usuario.UserName, usuario.Password);
            
            
            /*
            if (usuario.UserName == "humberto" 
                && usuario.Password == "123456789")
            {
                return new Usuario(usuario.UserName, usuario.Password);
            }
            */
            return _context.Usuario.Where(p => p.UserName == usuario.UserName
                && p.Password == usuario.Password).FirstOrDefault();

            //return _context.Produto.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
