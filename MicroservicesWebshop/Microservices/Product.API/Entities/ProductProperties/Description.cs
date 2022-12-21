using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.API.Entities.ProductProperties
{
    [BsonIgnoreExtraElements]
    public class Description
    {
        [BsonId]
        public string? Id { get; set; }

        [BsonElement("title")]
        public string? Title { get; set; }

        [BsonElement("details")]
        public string? Details { get; set; }
    }
}
