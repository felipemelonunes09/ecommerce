using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository productRepository;
        public GetAllProductsHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = await this.productRepository.GetProducts();
            var productsResponseList = ProductMapper.Mapper.Map<IList<ProductResponse>>(productList);
            return productsResponseList;
        }
    }
}