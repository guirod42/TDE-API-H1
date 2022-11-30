using Aula01.Data.Repository;
using Aula01.Domain;
using Aula01.Domain.Interfaces;
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
            if (buscarFornecedor == null) throw new Exception("Categoria não encontrada");
            buscarFornecedor.Nome = fornecedor.Nome;
            _fornecedorRepository.Atualizar(_mapper.Map<Fornecedor>(buscarFornecedor));
        }

        public void Cadastrar(FornecedorViewModel fornecedor)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<FornecedorViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
