using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers {

    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdCommand, bool>
    {
        private readonly IProductRepository productRepository;
        public DeleteProductByIdHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.DeleteProduct(request.Id);
        }
    }
}