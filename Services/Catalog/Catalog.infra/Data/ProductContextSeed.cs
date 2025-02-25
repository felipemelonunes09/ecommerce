using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infra.Data {
    public static class ProductContextSeed {
        public static void SeedData(IMongoCollection<Product> productCollection) {
            bool isPopulated = productCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if (!isPopulated) {
                var productData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                if (products != null) {
                    foreach (var p in products) {
                        productCollection.InsertOneAsync(p);
                    }
                }
            }
        }
    }
}