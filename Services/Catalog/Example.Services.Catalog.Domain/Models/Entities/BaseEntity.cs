using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Example.Services.Catalog.Domain.Models.Entities
{
    public abstract class BaseEntity
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }
    }
}
