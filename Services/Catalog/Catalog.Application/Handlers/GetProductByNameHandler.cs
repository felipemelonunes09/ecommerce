using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers {
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository productRepository;
        public GetProductByNameHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var product = await this.productRepository.GetProductsByName(request.Name);
            var productResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(product);
            return productResponse;
        }
    }
}