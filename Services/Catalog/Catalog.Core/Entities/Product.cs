using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities
{
    public abstract class Product : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public ProductBrand Brands { get; set; }
        public ProductType Type { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal Price { get; set; }
    }
}