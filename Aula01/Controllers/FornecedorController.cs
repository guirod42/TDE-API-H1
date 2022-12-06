using Aula01.Data.Repository;
using Aula01.Domain;
using Aula01.Domain.Enum;
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
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        //[Authorize]
        [Route("Cadastrar")]
        [HttpPost]
		public IActionResult Cadastrar(
            [FromForm] FornecedorViewModel fornecedor)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _fornecedorService.Cadastrar(fornecedor);

                return Ok(new { status = 200, message = "Fornecedor cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        //[Authorize]
        [Route("Atualizar")]
        [HttpPut]
        public async Task<IActionResult> Atualizar(int Id, [FromForm] FornecedorViewModel fornecedor)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _fornecedorService.Atualizar(fornecedor);

                return Ok(new { status = 200, message = "Fornecedor Atualizado com sucesso!" });
            }
            catch (Exception ex)
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

                _fornecedorService.Ativar(id);

                return Ok(new { status = 200, message = "Fornecedor ativado com sucesso!" });
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

                _fornecedorService.Desativar(id);

                return Ok(new { status = 200, message = "Fornecedor ativado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Authorize]
        [Route("ObterporID")]
        [HttpGet]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var buscarFornecedor = _fornecedorService.ObterFornecedorId(id);
                return Ok(
                    new
                    {
                        success = true,
                        categoria = buscarFornecedor
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
                var fornecedores = _fornecedorService.ObterTodos();
                return Ok(
                    new
                    {
                        success = true,
                        fornecedore = fornecedores
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
