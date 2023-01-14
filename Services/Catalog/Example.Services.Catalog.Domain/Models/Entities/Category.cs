using Example.Services.Catalog.Domain.Models.Commands;
using Example.Services.Catalog.Domain.Models.Entities.Base;

namespace Example.Services.Catalog.Domain.Models.Entities
{
    public class Category : MongoEntity
    {
        public Category() { }
        public Category(CreateCategoryCommand command) { Name = command.Name; }

        public string Name { get; set; }
    }
}
