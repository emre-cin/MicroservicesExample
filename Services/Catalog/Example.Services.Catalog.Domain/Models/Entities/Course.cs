using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Example.Services.Catalog.Domain.Models.Entities
{
    public class Course : BaseEntity
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        public string Name { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public Feature Feature { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
}
