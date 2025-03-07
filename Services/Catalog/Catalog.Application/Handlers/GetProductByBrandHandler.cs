using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers {
    public class GetProductByBrandHandler : IRequestHandler<GetProductByBrandQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository productRepository;
        public GetProductByBrandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
        {
            var product = await this.productRepository.GetProductsByBrand(request.brandName);
            var productResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(product);
            return productResponse;
        }
    }
}