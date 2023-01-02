using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Example.Services.Catalog.Domain.Models.Entities.Base
{
    public abstract class MongoEntity : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        [BsonElement(Order = 0)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 101)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 102)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
