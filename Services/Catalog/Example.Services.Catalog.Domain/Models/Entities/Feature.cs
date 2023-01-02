using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Example.Services.Catalog.Domain.Models.Entities.Base;

namespace Example.Services.Catalog.Domain.Models.Entities
{
    public class Feature : MongoEntity
    {
        public int Duration { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsDownloadable { get; set; }
    }
}
