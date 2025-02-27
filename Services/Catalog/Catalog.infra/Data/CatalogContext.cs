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
        }
    }
}