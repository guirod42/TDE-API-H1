using Aula01.Data.Repository;
using Aula01.Domain;
using Aula01.Domain.Enum;
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
    public class FornecedorController : Controller
	{
		private readonly IFornecedorRepository _fornecedorRepository;
		private IMapper _mapper;
		
		public FornecedorController(
			IFornecedorRepository fornecedorRepository,
			IMapper mapper)
		{
			_fornecedorRepository = fornecedorRepository;
			_mapper = mapper;
		}

        //[Authorize]
        [Route("Cadastrar")]
        [HttpPost]
		public async Task<IActionResult> Cadastrar([FromForm] FornecedorViewModel fornecedor)
		{
            if (!ModelState.IsValid) return BadRequest(ModelState);

            ValidDoc validDoc = null;
            if (fornecedor.TipoFornecedor == EnumTipoFornecedor.Fisico)
            {
                validDoc = await DocValidation.ValidCPF(fornecedor.Documento);
                if(!validDoc.Status) return Ok(new { success = false, mensagem = validDoc.Message });
            }
            if (fornecedor.TipoFornecedor == EnumTipoFornecedor.Juridico)
            {
                validDoc = await DocValidation.ValidCNPJ(fornecedor.Documento);
                if (!validDoc.Status) return Ok(new { success = false, mensagem = validDoc.Message });
            }

            if (fornecedor.ImageFile != null)
            {
                var imageName = Guid.NewGuid() + "_" + fornecedor.ImageFile.FileName;
                var validFile = await ImageValidation.UploadImage(fornecedor.ImageFile, imageName);
                if (!validFile.Status) return Ok(new { success = false, mensagem = validFile.Message });
                fornecedor.Imagem = Path.Combine(Directory.GetCurrentDirectory(), "Content/Images/", imageName);
            }
            else fornecedor.Imagem = "";

            fornecedor.Documento = validDoc.Numbers;
            fornecedor.Ativo = true;
            _fornecedorRepository.Cadastrar(_mapper.Map<Fornecedor>(fornecedor));
            return Ok(new { success = true, mensagem = "Fornecedor Cadastrado com sucesso" });
        }

        //[Authorize]
        [Route("Atualizar")]
        [HttpPut]
        public async Task<IActionResult> Atualizar(int Id, [FromForm] FornecedorViewModel fornecedor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var buscarFornecedor = _fornecedorRepository.ObterFornecedorId(Id);
            if (buscarFornecedor == null) return NotFound(new { status = 404, message = "Fornecedor não encontrado" });

            if (buscarFornecedor.Nome != null) buscarFornecedor.Nome = fornecedor.Nome;
            if (buscarFornecedor.TipoFornecedor != null) buscarFornecedor.TipoFornecedor = fornecedor.TipoFornecedor;            
            if (buscarFornecedor.Documento != null) buscarFornecedor.Documento = fornecedor.Documento;

            if (fornecedor.ImageFile != null)
            {
                var imageName = Guid.NewGuid() + "_" + fornecedor.ImageFile.FileName;
                var validFile = await ImageValidation.UploadImage(fornecedor.ImageFile, imageName);
                if (!validFile.Status) return Ok(new { success = false, mensagem = validFile.Message });
                buscarFornecedor.Imagem = Path.Combine(Directory.GetCurrentDirectory(), "Content/Images/", imageName);
            }

            _fornecedorRepository.Atualizar(_mapper.Map<Fornecedor>(buscarFornecedor));
            return Ok(new { status = 200, message = "Fornecedor Atualizado com sucesso!" });
        }

        //[Authorize]
        [Route("Ativar")]
        [HttpPut]
        public IActionResult Ativar(int id)
        {
            var buscarFornecedor = _fornecedorRepository.ObterFornecedorId(id);
            if (buscarFornecedor == null) return NotFound(new { status = 404, message = "Fornecedor não encontrado" });

            _fornecedorRepository.Ativar(buscarFornecedor);
            return Ok(new { status = 200, message = "Fornecedor Ativado com sucesso!" });
        }

        //[Authorize]
        [Route("Inativar")]
        [HttpPut]
        public IActionResult Inativar(int id)
        {
            var buscarCategoria = _fornecedorRepository.ObterFornecedorId(id);
            if (buscarCategoria == null) return NotFound(new { status = 404, message = "Fornecedor não encontrado" });

            _fornecedorRepository.Desativar(buscarCategoria);
            return Ok(new { status = 200, message = "Fornecedor Inativado com sucesso!" });
        }

        [Authorize]
        [Route("ObterporID")]
        [HttpGet]
        public IActionResult ObterPorId(int id)
        {
            var pesquisa = _mapper.Map<FornecedorViewModel>(_fornecedorRepository.ObterFornecedorId(id));
            if (pesquisa == null) return NotFound(new { status = 404, message = "Fornecedor não encontrado" });
            return Ok(
                new
                {
                    success = true,
                    fornecedor = pesquisa
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
                    listaFornecedeores = _mapper.Map<IEnumerable<FornecedorViewModel>>(_fornecedorRepository.ObterTodos())
                }
                );
        }
    }
}
