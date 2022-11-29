using Aula01.Data.Repository;
using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Domain.Validations;
using Aula01.Model;
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
        private readonly ICategoriaRepository _categoriaRepository;
        private IMapper _mapper;

        public CategoriaController(
            ICategoriaRepository categoriaRepository,
            IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        //[Authorize]
        [Route("Cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar(
            [FromForm] CategoriaViewModel categoria)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            categoria.Ativo = true;
            _categoriaRepository.Cadastrar(_mapper.Map<Categoria>(categoria));
            return Ok(new { success = true, mensagem = "Categoria Cadastrada com sucesso" });
        }

        //[Authorize]
        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar(int id, string nome)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var buscarCategoria = _categoriaRepository.ObterCategoriaId(id);
            if (buscarCategoria == null) return NotFound(new { status = 404, message = "Categoria não encontrada" });
            buscarCategoria.Nome = nome;
            _categoriaRepository.Atualizar(_mapper.Map<Categoria>(buscarCategoria));
            return Ok(new { status = 200, message = "Categoria Atualizada com sucesso!" });
        }

        //[Authorize]
        [Route("Ativar")]
        [HttpPut]
        public IActionResult Ativar(int id)
        {
            var buscarCategoria = _categoriaRepository.ObterCategoriaId(id);
            if (buscarCategoria == null) return NotFound(new { status = 404, message = "Categoria não encontrada" });
            _categoriaRepository.Ativar(buscarCategoria);
            return Ok(new { status = 200, message = "Categoria Ativada com sucesso!" });
        }

        //[Authorize]
        [Route("Inativar")]
        [HttpPut]
        public IActionResult Inativar(int id)
        {
            var buscarCategoria = _categoriaRepository.ObterCategoriaId(id);
            if (buscarCategoria == null) return NotFound(new { status = 404, message = "Categoria não encontrada" });
            _categoriaRepository.Desativar(buscarCategoria);
            return Ok(new { status = 200, message = "Categoria Inativada com sucesso!" });
        }

        //[Authorize]
        [Route("ObterPorID")]
        [HttpGet]
        public IActionResult ObterPorId(int id)
        {
            var pesquisa = _mapper.Map<CategoriaViewModel>(_categoriaRepository.ObterCategoriaId(id));
            if (pesquisa == null) return NotFound(new { status = 404, message = "Categoria não encontrada" });
            return Ok(
                new
                {
                    success = true,
                    produto = pesquisa
                }
                );
        }

        //[Authorize]
        [Route("ObterTodos")]
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(
                new
                {
                    success = true,
                    listaProdutos = _mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaRepository.ObterTodos())
                }
                );
        }
    }
}
