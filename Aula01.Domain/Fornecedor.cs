using Aula01.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain
{
	public class Fornecedor : Entity
    {
        protected Fornecedor()
        {

        }

        public Fornecedor(string nome,
            EnumTipoFornecedor tipoFornecedor,
            //int tipoFornecedor,
            string documento,
            string imagem)
		{
            Nome = nome;
			TipoFornecedor = tipoFornecedor;
			Documento = documento;
			Imagem = imagem;
            Ativo = true;
		}

		public string Nome { get; set; }
        public EnumTipoFornecedor TipoFornecedor { get; set; }
        //public int TipoFornecedor { get; set; }
        public string Documento { get; set; }
		public string Imagem { get; set; }
	}
}
