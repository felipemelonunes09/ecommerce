using System.Runtime.InteropServices;
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

        public async Task<IEnumerable<Product>> GetProductsByBrand(string brandName)
        {
            return await this.context
                .Products
                .Find(p => p.Brands.Name.ToLower() == brandName.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await this.context
                .Products
                .Find(p => p.Name.ToLower() == name.ToLower())
                .ToListAsync();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await this.context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deletedProduct = await this.context
                .Products
                .DeleteOneAsync(p => p.Id == id);
            return deletedProduct.IsAcknowledged && deletedProduct.DeletedCount > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updatedProduct = await this.context
                .Products
                .ReplaceOneAsync(p => p.Id == product.Id, product);
            return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
        }

        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            return await this.context
                .Brands
                .Find(b => true)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            return await this.context
                .Types
                .Find(t => true)
                .ToListAsync();
        }
    }
}