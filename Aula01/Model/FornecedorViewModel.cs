using Aula01.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace Aula01.Model
{
	public class FornecedorViewModel
	{
		[SwaggerSchema(ReadOnly = true)]
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Nome { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, 2, ErrorMessage = "Valor de {0} deve entre {1} e {2}.")]
        public EnumTipoFornecedor TipoFornecedor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
		public string Documento { get;  set; }
		
		[SwaggerSchema(ReadOnly = true)]
		public string? Imagem { get; set; }

        [JsonIgnore]
        public IFormFile? ImageFile { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public bool Ativo { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string CriadoPor { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime CriadoEm { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string AtualizadoPor { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime AtualizadoEm { get; set; }
    }
}
