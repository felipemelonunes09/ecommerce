using MediatR;
using Catalog.Application.Responses;

namespace Catalog.Application.Queries
{
    public class GetAllBrandsQuery :IRequest<IList<BrandResponse>>
    {
    }
}