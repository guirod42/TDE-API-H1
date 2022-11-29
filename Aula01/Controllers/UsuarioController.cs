using Aula01.Data.Repository;
using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using Aula01.Token;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        //[Authorize]
        [Route("User Login")]
        [HttpPost]
        public async Task<ActionResult<dynamic>> Autenticate([FromBody] UsuarioViewModel usuarioViewModel)
        {
            // Localiza o usuario
            var buscaUsuario = _usuarioRepository.Autenticar(_mapper.Map<Usuario>(usuarioViewModel));

            // Verifica a existência
            if (buscaUsuario == null)
                return NotFound(new {message = "Usuário não existe e/ou Senha inválida"});

            // Gerando o Token
            var token = TokenService.GenerateToken(buscaUsuario);

            // Ocultar a senha
            buscaUsuario.Password = "";

            return new
            {
                usuario = buscaUsuario.UserName,
                token = "Bearer " + token
            };
        }
    }
}
