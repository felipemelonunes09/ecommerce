using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.VisualBasic;

namespace Catalog.Application.Handlers {
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = ProductMapper.Mapper.Map<Product>(request);
            if (product is null) {
                throw new ApplicationException("There was an error mapping the product");
            }

            var newProduct = await this.productRepository.CreateProduct(product);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
            return productResponse;
        }
    }
}