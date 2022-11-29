using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain
{
    public abstract class Entity
    {
        protected Entity()
        {
          
        }

        public int Id { get; set; }
        public bool Ativo { get; set; }
        //public string CriadoPor { get; set; }
        //public DateTime CriadoEm { get; set; }
        //public string AtualizadoPor { get; set; }
        //public DateTime AtualizadoEm{ get; set; }

        public void On()
        {
            Ativo = true;
        }

        public void Off()
        {
            Ativo = false;
        }
    }
}
