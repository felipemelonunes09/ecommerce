using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;

namespace Catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() {
            this.CreateMap<ProductBrand, BrandResponse>().ReverseMap();
            this.CreateMap<Product, ProductResponse>().ReverseMap();
        }
    }
}