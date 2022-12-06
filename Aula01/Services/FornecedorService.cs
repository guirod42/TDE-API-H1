using Aula01.Data.Repository;
using Aula01.Domain;
using Aula01.Domain.Enum;
using Aula01.Domain.Interfaces;
using Aula01.Domain.Validations;
using Aula01.Model;
using AutoMapper;

namespace Aula01.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public void Ativar(int id)
        {
            var buscarFornecedor = _fornecedorRepository.ObterFornecedorId(id);
            if (buscarFornecedor == null) throw new Exception("Fornecedor não encontrado");
            if (buscarFornecedor.Ativo == true) throw new Exception("Este fornecedor já estava ativo");
            _fornecedorRepository.Ativar(buscarFornecedor);
        }

        public void Atualizar(FornecedorViewModel fornecedor)
        {
            var buscarFornecedor = _fornecedorRepository.ObterFornecedorId(fornecedor.Id);
            if (buscarFornecedor == null) throw new Exception("Fornecedor não encontrado");

            if (fornecedor.Nome != null) buscarFornecedor.Nome = fornecedor.Nome;

            if (fornecedor.Documento != null)
            {
                ValidDoc validDoc = null;
                string docNormalizado = "";
                if (fornecedor.TipoFornecedor == EnumTipoFornecedor.Fisico)
                {
                    validDoc = DocValidation.ValidCPF(fornecedor.Documento);
                    docNormalizado = validDoc.Numbers;
                    if (validDoc.Status == false) throw new Exception(validDoc.Message);
                }
                if (fornecedor.TipoFornecedor == EnumTipoFornecedor.Juridico)
                {
                    validDoc = DocValidation.ValidCNPJ(fornecedor.Documento);
                    docNormalizado = validDoc.Numbers;
                    if (validDoc.Status == false) throw new Exception(validDoc.Message);
                }
                buscarFornecedor.Documento = docNormalizado;
            }

            if (fornecedor.ImageFile != null)
            {
                var imageName = Guid.NewGuid() + "_" + fornecedor.ImageFile.FileName;
                var validFile = ImageValidation.UploadImage(fornecedor.ImageFile, imageName);
                //return Ok(new { success = false, mensagem = validFile.Message });
                if (validFile.Status == false) throw new Exception(validFile.Message);
                fornecedor.Imagem = Path.Combine(Directory.GetCurrentDirectory(), "Content/Images/", imageName);
            }
            _fornecedorRepository.Atualizar(_mapper.Map<Fornecedor>(buscarFornecedor));
        }

        public void Cadastrar(FornecedorViewModel fornecedor)
        {
            ValidDoc validDoc = null;            
            string docNormalizado = "";
            if (fornecedor.TipoFornecedor == EnumTipoFornecedor.Fisico)
            {
                validDoc = DocValidation.ValidCPF(fornecedor.Documento);
                docNormalizado = validDoc.Numbers;
                if (validDoc.Status == false) throw new Exception(validDoc.Message);
            }
            if (fornecedor.TipoFornecedor == EnumTipoFornecedor.Juridico)
            {
                validDoc = DocValidation.ValidCNPJ(fornecedor.Documento);
                docNormalizado = validDoc.Numbers;
                if (validDoc.Status == false) throw new Exception(validDoc.Message);
            }
            
            if (fornecedor.ImageFile != null)
            {
                var imageName = Guid.NewGuid() + "_" + fornecedor.ImageFile.FileName;
                var validFile = ImageValidation.UploadImage(fornecedor.ImageFile, imageName);
                //return Ok(new { success = false, mensagem = validFile.Message });
                if (validFile.Status == false) throw new Exception(validFile.Message);
                fornecedor.Imagem = Path.Combine(Directory.GetCurrentDirectory(), "Content/Images/", imageName);
            }
            else fornecedor.Imagem = "";
            fornecedor.Documento = docNormalizado;
            fornecedor.Ativo = true;
            _fornecedorRepository.Cadastrar(_mapper.Map<Fornecedor>(fornecedor));
        }

        public void Desativar(int id)
        {
            var buscarFornecedor = _fornecedorRepository.ObterFornecedorId(id);
            if (buscarFornecedor == null) throw new Exception("Fornecedor não encontrado");
            if (buscarFornecedor.Ativo == false) throw new Exception("Este fornecedor já estava inativo");
            _fornecedorRepository.Desativar(buscarFornecedor);
        }

        public FornecedorViewModel ObterFornecedorId(int id)
        {
            var buscarFornecedor = _mapper.Map<FornecedorViewModel>(_fornecedorRepository.ObterFornecedorId(id));
            if (buscarFornecedor == null) throw new Exception("Fornecedor não encontrado");
            return buscarFornecedor;
        }

        public IEnumerable<FornecedorViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(_fornecedorRepository.ObterTodos());
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
