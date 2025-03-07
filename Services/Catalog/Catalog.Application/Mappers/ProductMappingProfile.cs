using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;

namespace Catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() {
            this.CreateMap<ProductBrand, BrandResponse>().ReverseMap();
            this.CreateMap<Product, ProductResponse>().ReverseMap();
            this.CreateMap<ProductType, TypesResponse>().ReverseMap();
            this.CreateMap<Product, CreateProductCommand>().ReverseMap();
        }
    }
}