namespace Example.Services.Catalog.Domain.Models.Entities.Base
{
    public interface IEntity
    {
        public string Id { get; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }

}
