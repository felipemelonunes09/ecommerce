using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infra.Data;
using MongoDB.Driver;

namespace Catalog.Infra.Repositories {
    public class ProductRepository : IProductRepository, IBrandRepository, ITypesRepository
    {
        private ICatalogContext context;
        public ProductRepository(ICatalogContext context)
        {
            this.context = context;
        }
        public async Task<Product> GetProduct(string id)
        {
            return await this.context
                .Products
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await this.context
                .Products
                .Find(p => true)
                .ToListAsync();
        }
        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Type>> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByBrand(string brand)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}