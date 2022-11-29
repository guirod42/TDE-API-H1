using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Aula01.Model
{
	public class ProdutoViewModel
	{
		[SwaggerSchema(ReadOnly = true)]
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Nome { get; set; }
		
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[Range(0, 1000000000, ErrorMessage = "O valor de {0} deve estar entre {1} e {2}.")]
		public decimal Preco { get; set; }
		
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[Range(0, 1000000000, ErrorMessage = "O valor de {0} deve estar entre {1} e {2} unidades.")]
		public int Estoque { get; set; }

		[SwaggerSchema(ReadOnly = true)]
		public string? Imagem { get; set; }

		[JsonIgnore]
        public IFormFile? ImageFile { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public bool Ativo { get; set; }
	}
}
