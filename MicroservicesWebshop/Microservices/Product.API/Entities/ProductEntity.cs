using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Product.API.Entities.ProductProperties;

namespace Product.API.Entities
{
    [BsonIgnoreExtraElements]
    public class ProductEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("productCode")]
        public string? ProductCode { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("price")]
        public float Price { get; set; }

        [BsonElement("stock")]
        public int Stock { get; set; }

        [BsonElement("categoryId")]
        public string? CategoryId { get; set; }

        [BsonElement("category")]
        public CategoryEntity? Category { get; set; }

        [BsonElement("description")]
        public Description? Description { get; set; }

        [BsonElement("technicalSpecifications")]
        public TechnicalSpecifications? TechnicalSpecifications { get; set; }

        [BsonElement("reviews")]
        public ICollection<Review>? Reviews { get; set; } 
    }
}
