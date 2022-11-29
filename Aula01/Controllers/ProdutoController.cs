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
    public class ProdutoController : Controller
	{
		private readonly IProdutoRepository _produtoRepository;
		private IMapper _mapper;

		public ProdutoController(
			IProdutoRepository produtoRepository,
			IMapper mapper)
		{
			_produtoRepository = produtoRepository;
			_mapper = mapper;
		}

        //[Authorize]
        [Route("Cadastrar")]
        [HttpPost]
		public async Task<IActionResult> Cadastrar([FromForm] ProdutoViewModel produto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			if (produto.ImageFile != null)
			{
				var imageName = Guid.NewGuid() + "_" + produto.ImageFile.FileName;
				var validFile = await ImageValidation.UploadImage(produto.ImageFile, imageName);
				if (!validFile.Status) return Ok(new { success = false, mensagem = validFile.Message });
				produto.Imagem = Path.Combine(Directory.GetCurrentDirectory(), "Content/Images/", imageName);
			}
            else produto.Imagem = "";

            produto.Ativo = true;

			_produtoRepository.Cadastrar(_mapper.Map<Produto>(produto));
			return Ok(new { success = true, mensagem = "Produto Cadastrado com sucesso" });
        }

        //[Authorize]
        [Route("Atualizar")]
        [HttpPut]
        public async Task<IActionResult> Atualizar(int Id, [FromForm] ProdutoViewModel produto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var buscarProduto = _produtoRepository.ObterProdutoId(Id);
            if (buscarProduto == null) return NotFound(new { status = 404, message = "Produto não encontrado" });

            if (buscarProduto.Nome != null) buscarProduto.Nome = produto.Nome;
            if (buscarProduto.Preco != null) buscarProduto.Preco = produto.Preco;
            if (buscarProduto.Estoque != null) buscarProduto.Estoque = produto.Estoque;

            if (produto.ImageFile != null)
            {
                var imageName = Guid.NewGuid() + "_" + produto.ImageFile.FileName;
                var validFile = await ImageValidation.UploadImage(produto.ImageFile, imageName);
                if (!validFile.Status) return Ok(new { success = false, mensagem = validFile.Message });
                buscarProduto.Imagem = Path.Combine(Directory.GetCurrentDirectory(), "Content/Images/", imageName);
            }

            _produtoRepository.Atualizar(_mapper.Map<Produto>(buscarProduto));
            return Ok(new { status = 200, message = "Produto Atualizado com sucesso!" });
        }

        //[Authorize]
        [Route("Ativar")]
        [HttpPut]
        public IActionResult Ativar(int id)
        {
            var buscarProduto = _produtoRepository.ObterProdutoId(id);
            if (buscarProduto == null) return NotFound(new { status = 404, message = "Produto não encontrado" });

            _produtoRepository.Ativar(buscarProduto);
            return Ok(new { status = 200, message = "Produto Ativado com sucesso!" });
        }

        //[Authorize]
        [Route("Inativar")]
        [HttpPut]
        public IActionResult Inativar(int id)
        {
            var buscarProduto = _produtoRepository.ObterProdutoId(id);
            if (buscarProduto == null) return NotFound(new { status = 404, message = "Produto não encontrado" });

            _produtoRepository.Desativar(buscarProduto);
            return Ok(new { status = 200, message = "Produto Inativado com sucesso!" });
        }

        //[Authorize]
        [Route("Obter por ID")]
        [HttpGet]
		public IActionResult ObterPorId(int id)
		{
			var pesquisa = _mapper.Map<ProdutoViewModel>(_produtoRepository.ObterProdutoId(id));
			if (pesquisa == null) return NotFound();
			return Ok(
				new
				{
					success = true,
					produto = pesquisa
				}
				);
		}

        //[Authorize]
        [Route("Obter Todos")]
		[HttpGet]
		public IActionResult ObterTodos()
		{
			return Ok(
				new
				{
					success = true,
					listaProdutos = _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterTodos())
				}
				);
		}
    }
}
