using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypesResponse>>
    {
        private readonly ITypesRepository typesRepository;
        public GetAllTypesHandler(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }
        public async Task<IList<TypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typesList = await this.typesRepository.GetAllTypes();
            var typeResponseList = ProductMapper.Mapper.Map<IList<TypesResponse>>(typesList);
            return typeResponseList;
        }
    }
}