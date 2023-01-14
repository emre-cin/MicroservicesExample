using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Example.Services.Catalog.Domain.Models.Entities.Base;
using Example.Services.Catalog.Domain.Models.Commands;

namespace Example.Services.Catalog.Domain.Models.Entities
{
    public class Course : MongoEntity
    {
        public Course()
        {

        }
        public Course(CreateCourseCommand command)
        {
            UserId = command.UserId;
            CategoryId = command.CategoryId;
            Name = command.Name;
            Price = command.Price;
            Picture = command.Picture;
            Description = command.Description;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
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
