using Aula01.Data.Repository;
using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Domain.Validations;
using Aula01.Model;
using Aula01.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Aula01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        //[Authorize]
        [Route("Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar(
            [FromForm] CategoriaViewModel categoria)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _categoriaService.Cadastrar(categoria);

                return Ok(new { success = true, mensagem = "Categoria cadastrada com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        //[Authorize]
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar(int id, string nome)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _categoriaService.Atualizar(id, nome);

                return Ok(new { status = 200, message = "Categoria Atualizada com sucesso!" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        //[Authorize]
        [Route("Ativar")]
        [HttpPut]
        public IActionResult Ativar(int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _categoriaService.Ativar(id);

                return Ok(new { status = 200, message = "Categoria Ativada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        //[Authorize]
        [Route("Inativar")]
        [HttpPut]
        public IActionResult Inativar(int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _categoriaService.Desativar(id);

                return Ok(new { status = 200, message = "Categoria Inativada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Authorize]
        [Route("ObterPorID")]
        [HttpGet]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var categoriaProc = _categoriaService.ObterCategoriaId(id);
                return Ok(
                    new
                    {
                        success = true,
                        categoria = categoriaProc
                    }
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        //[Authorize]
        [Route("ObterTodos")]
        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                var categorias = _categoriaService.ObterTodos();
                return Ok(
                    new
                    {
                        success = true,
                        categoria = categorias
                    }
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }            
        }
    }
}
