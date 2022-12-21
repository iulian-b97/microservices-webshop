using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Product.API.Entities.ProductProperties
{
    public class Review
    {
        [BsonId]
        public string? Id { get; set; }

        [BsonElement("customerName")]
        public string? CustomerName { get; set; }

        [BsonElement("note")]
        public int Note { get; set; }

        [BsonElement("comment")]
        public string? Comment { get; set; }
    }
}
