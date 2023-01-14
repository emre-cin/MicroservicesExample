using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Shared.Dtos;
using MediatR;

namespace Example.Services.Catalog.Domain.Models.Commands
{
    public class CreateCategoryCommand : IRequest<Response<CategoryDto>>
    {
        public string Name { get; set; }
    }
}
