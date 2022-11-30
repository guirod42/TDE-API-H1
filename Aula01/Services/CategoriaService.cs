using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using AutoMapper;

namespace Aula01.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public void Ativar(CategoriaViewModel categoria)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(CategoriaViewModel categoria)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(CategoriaViewModel categoria)
        {
            categoria.Ativo = true;
            //so vou cadastrar se nome existe
            //throw  new Exception("Nome Já existe, operação realizada");
            //
            _categoriaRepository.Cadastrar(_mapper.Map<Categoria>(categoria));
        }

        public void Desativar(CategoriaViewModel categoria)
        {
            throw new NotImplementedException();
        }

        public CategoriaViewModel ObterCategoriaId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
