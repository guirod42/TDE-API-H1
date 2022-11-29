using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using Aula01.Token;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [Route("UserLogin")]
        [HttpPost]
        public async Task<ActionResult<dynamic>> Autenticate([FromForm] UsuarioViewModel usuarioViewModel)
        {
            // Localiza o usuario
            var buscaUsuario = _usuarioRepository.Autenticar(_mapper.Map<Usuario>(usuarioViewModel));
            buscaUsuario.Password = "";

            // Verifica a existência
            if (buscaUsuario == null)
                return NotFound(new {message = "Usuário não existe e/ou Senha inválida"});

            // Gerando o Token
            var token = TokenService.GenerateToken(buscaUsuario);

            // Ocultar a senha
            if (!buscaUsuario.Ativo)
            {
                return new
                {
                    Situacao = "O usuário " + buscaUsuario.UserName + " está desativado, solicite que um Adm reative o usuário!"
                };
            }

            else
            {
                return new
                {
                    usuario = buscaUsuario.UserName,
                    token = "Bearer " + token
                };
            }
        }

        [Authorize]
        [Route("Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar(
            [FromForm] UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            usuario.Ativo = true;
            _usuarioRepository.Cadastrar(_mapper.Map<Usuario>(usuario));
            return Ok(new { success = true, mensagem = "Novo usuário cadastrado!" });
        }

        [Authorize]
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar(string usuario, string senha, string senharepetida)
        {
            if (senha != senharepetida) return NotFound(new { status = 404, message = "Repita a nova senha duas vezes!!" });
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var buscarUsuario = _usuarioRepository.Localizar(usuario);
            if (buscarUsuario == null) return NotFound(new { status = 404, message = "Usuario não existe" });
            buscarUsuario.Password = senha;
            _usuarioRepository.Atualizar(_mapper.Map<Usuario>(buscarUsuario));
            return Ok(new { status = 200, message = "Senha atualizada!" });
        }

        [Authorize]
        [Route("Ativar")]
        [HttpPut]
        public IActionResult Ativar(string usuario)
        {
            var buscarUsuario = _usuarioRepository.Localizar(usuario);
            if (buscarUsuario == null) return NotFound(new { status = 404, message = "Usuário não existe" });
            _usuarioRepository.Ativar(buscarUsuario);
            return Ok(new { status = 200, message = "Usuário ativado!" });
        }

        [Authorize]
        [Route("Inativar")]
        [HttpPut]
        public IActionResult Inativar(string usuario)
        {
            var buscarUsuario = _usuarioRepository.Localizar(usuario);
            if (buscarUsuario == null) return NotFound(new { status = 404, message = "Usuario não existe" });
            _usuarioRepository.Desativar(buscarUsuario);
            return Ok(new { status = 200, message = "Usuário desativado!" });
        }

        // No usuario controller criar as ações de inserir um usuario e atualizar
    }
}
