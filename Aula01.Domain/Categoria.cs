using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain
{
    public class Categoria : Entity
    {
        protected Categoria()
        {

        }

        public Categoria(string nome)
        {
            Nome = nome;
            Ativo = true;
        }
        public string Nome { get; set; }
    }
}
