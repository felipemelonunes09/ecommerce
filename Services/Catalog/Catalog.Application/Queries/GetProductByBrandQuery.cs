using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries{
    public class GetProductByBrandQuery: IRequest<IList<ProductResponse>> {
        public string brandName { get; set; }
        public GetProductByBrandQuery(string brandName) {
            this.brandName = brandName;
        }
    }
}