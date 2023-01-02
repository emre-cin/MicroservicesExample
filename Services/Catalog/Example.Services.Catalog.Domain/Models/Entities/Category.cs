using Example.Services.Catalog.Domain.Models.Entities.Base;

namespace Example.Services.Catalog.Domain.Models.Entities
{
    public class Category : MongoEntity
    {
        public string Name { get; set; }
    }
}
