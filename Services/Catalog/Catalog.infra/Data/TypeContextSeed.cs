using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infra.Data {
    public static class TypeContextSeed {
        public static void seedData(IMongoCollection<ProductType> typeCollection) {
            bool isPopulated = typeCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "types.json");
            if (!isPopulated) {
                var typesData = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types != null) {
                    foreach (var t in types) {
                        typeCollection.InsertOneAsync(t);
                    }
                }
            }
        }
    }
}