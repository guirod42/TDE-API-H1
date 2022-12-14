using Aula01.Domain;
using Aula01.Model;
using AutoMapper;

namespace Aula01.Mapper
{
	public class DomainToApplication : Profile
	{
		public DomainToApplication()
		{
            CreateMap<Usuario, UsuarioViewModel>();
			CreateMap<Produto, ProdutoViewModel>();
			CreateMap<Fornecedor, FornecedorViewModel>();
			CreateMap<Categoria, CategoriaViewModel>();
        }		
	}
}
