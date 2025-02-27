using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infra.Data {
    public class CatalogContext: ICatalogContext {
        public IMongoCollection<Product> Products { get; }        
        public IMongoCollection<ProductBrand> Brands { get;}
        public IMongoCollection<ProductType> Types { get;}

        public CatalogContext(IConfiguration configuration) {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            this.Brands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSettings:BrandsCollectionName"));
            this.Types = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSettings:TypesCollectionName"));
            this.Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:ProductsCollectionName"));

            BrandContextSeed.SeedData(this.Brands);
            TypeContextSeed.SeedData(this.Types);
            ProductContextSeed.SeedData(this.Products);
        }
    }
}