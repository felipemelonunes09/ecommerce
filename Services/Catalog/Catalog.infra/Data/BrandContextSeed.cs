using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infra.Data {
    public static class BrandContextSeed {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection) {
            bool isPopulated = brandCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "brands.json");
            if (!isPopulated) {
                var brandsData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands != null) {
                    foreach (var brand in brands) {
                        brandCollection.InsertOneAsync(brand);
                    }
                }
            }
        }
    }
}