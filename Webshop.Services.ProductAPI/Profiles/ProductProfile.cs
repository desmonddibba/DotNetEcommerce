using AutoMapper;
using Webshop.Services.ProductAPI.Models;
using Webshop.Services.ProductAPI.Models.Dtos;

namespace Webshop.Services.ProductAPI.Profiles
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			// Src -> Target

			// Mapping Product to ProductDto and reverse
			CreateMap<Product, ProductDto>().ReverseMap();

			// Mapping for creating a new product
			CreateMap<Product, ProductCreateDto>().ReverseMap();

			// Mapping for updating an existing product
			CreateMap<Product, ProductUpdateDto>().ReverseMap();
		}
	}
}
