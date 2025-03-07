using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers {
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository productRepository;
        public UpdateProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // this is without the mapper
            var productEntity = await this.productRepository.UpdateProduct(new Product {
                Id          = request.Id,
                Name        = request.Name,
                Description = request.Description,
                Price       = request.Price,
                ImageFile   = request.ImageFile,
                Type        = request.Type,
                Brands      = request.Brands
            });

            return true;
        }
    }
}