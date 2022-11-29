using Aula01.Domain;
using Aula01.Model;
using AutoMapper;

namespace Aula01.Mapper
{
	public class ApplicationToDomain : Profile
	{
		public ApplicationToDomain()
		{
            CreateMap<UsuarioViewModel, Usuario>()
                .ConstructUsing(f => new Usuario(f.Username, f.Password));

			CreateMap<ProdutoViewModel, Produto>()
			   .ConstructUsing(f => new Produto(f.Nome, f.Preco, f.Estoque, f.Imagem));

			CreateMap<FornecedorViewModel, Fornecedor>()
				.ConstructUsing(f => new Fornecedor(f.Nome, f.TipoFornecedor, f.Documento, f.Imagem));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(f => new Categoria(f.Nome));
        }
	}
}

