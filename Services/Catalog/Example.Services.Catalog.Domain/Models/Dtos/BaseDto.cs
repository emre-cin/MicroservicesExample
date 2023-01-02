namespace Example.Services.Catalog.Domain.Models.Dtos
{
    public abstract class BaseDto
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
