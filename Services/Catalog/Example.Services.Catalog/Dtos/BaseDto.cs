namespace Example.Services.Catalog.Dtos
{
    public abstract class BaseDto
    {
        public string Id { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}