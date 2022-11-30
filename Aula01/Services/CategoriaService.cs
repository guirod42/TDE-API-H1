using Aula01.Data.Repository;
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

        public void Ativar(int id)
        {
            var buscarCategoria = _categoriaRepository.ObterCategoriaId(id);
            if (buscarCategoria == null) throw new Exception("Categoria não encontrada");
            if (buscarCategoria.Ativo == true) throw new Exception("Esta categoria já estava ativa");
            _categoriaRepository.Ativar(buscarCategoria);
        }

        public void Atualizar(int id, string nome)
        {
            var buscarCategoria = _categoriaRepository.ObterCategoriaId(id);
            if (buscarCategoria == null) throw new Exception("Categoria não encontrada");
            buscarCategoria.Nome = nome;
            _categoriaRepository.Atualizar(_mapper.Map<Categoria>(buscarCategoria));
        }

        public void Cadastrar(CategoriaViewModel categoria)
        {
            categoria.Ativo = true;
            //só vou cadastrar se nome ainda não existe
            //throw  new Exception("Nome Já existe, operação não realizada");
            //
            _categoriaRepository.Cadastrar(_mapper.Map<Categoria>(categoria));
        }

        public void Desativar(int id)
        {
            var buscarCategoria = _categoriaRepository.ObterCategoriaId(id);
            if (buscarCategoria == null) throw new Exception("Categoria não encontrada");
            if (buscarCategoria.Ativo == false) throw new Exception("Esta categoria já estava inativa");
            _categoriaRepository.Desativar(buscarCategoria);
        }

        public CategoriaViewModel ObterCategoriaId(int id)
        {
            var buscarCategoria = _mapper.Map<CategoriaViewModel>(_categoriaRepository.ObterCategoriaId(id));
            if (buscarCategoria == null) throw new Exception("Categoria não encontrada");
            return buscarCategoria;
        }

        public IEnumerable<CategoriaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaRepository.ObterTodos());
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}