using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;


namespace Aula01.Model
{
    public class CategoriaViewModel
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Nome { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public bool Ativo { get; set; }
    }
}
