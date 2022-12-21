using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Product.API.Entities.ProductProperties
{
    public class TechnicalSpecifications
    {
        [BsonId]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("mark")]
        public string? Mark { get; set; }

        [BsonElement("length")]
        public int Length { get; set; }

        [BsonElement("height")]
        public int Height { get; set; }

        [BsonElement("width")]
        public int Width { get; set; }

        [BsonElement("weight")]
        public float Weight { get; set; }
    }
}
