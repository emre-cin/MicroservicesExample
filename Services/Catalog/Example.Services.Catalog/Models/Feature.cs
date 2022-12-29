using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Example.Services.Catalog.Models
{
    public class Feature : BaseEntity
    {
        public int Duration { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsDownloadable { get; set; }
    }
}
