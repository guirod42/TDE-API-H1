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

        //private readonly IFornecedorRepository _fornecedorRepository;
        //private IMapper _mapper;

        //public FornecedorController(
        //	IFornecedorRepository fornecedorRepository,
        //	IMapper mapper)
        //{
        //	_fornecedorRepository = fornecedorRepository;
        //	_mapper = mapper;
        //}

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
            //          ValidDoc validDoc = null;
            //          if (fornecedor.TipoFornecedor == EnumTipoFornecedor.Fisico)
            //          {
            //              validDoc = await DocValidation.ValidCPF(fornecedor.Documento);
            //              if(!validDoc.Status) return Ok(new { success = false, mensagem = validDoc.Message });
            //          }
            //          if (fornecedor.TipoFornecedor == EnumTipoFornecedor.Juridico)
            //          {
            //              validDoc = await DocValidation.ValidCNPJ(fornecedor.Documento);
            //              if (!validDoc.Status) return Ok(new { success = false, mensagem = validDoc.Message });
            //          }

            //          if (fornecedor.ImageFile != null)
            //          {
            //              var imageName = Guid.NewGuid() + "_" + fornecedor.ImageFile.FileName;
            //              var validFile = await ImageValidation.UploadImage(fornecedor.ImageFile, imageName);
            //              if (!validFile.Status) return Ok(new { success = false, mensagem = validFile.Message });
            //              fornecedor.Imagem = Path.Combine(Directory.GetCurrentDirectory(), "Content/Images/", imageName);
            //          }
            //          else fornecedor.Imagem = "";

            //          fornecedor.Documento = validDoc.Numbers;
            //          fornecedor.Ativo = true;
            //          _fornecedorRepository.Cadastrar(_mapper.Map<Fornecedor>(fornecedor));
            //          return Ok(new { success = true, mensagem = "Fornecedor Cadastrado com sucesso" });
        }

        //[Authorize]
        [Route("Atualizar")]
        [HttpPut]
        public async Task<IActionResult> Atualizar(int Id, [FromForm] FornecedorViewModel fornecedor)
        {
            /*
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
            */
            return Ok(new { status = 200, message = "Fornecedor atualizado com sucesso!" });
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
