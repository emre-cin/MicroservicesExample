using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Shared.Dtos;
using MediatR;

namespace Example.Services.Catalog.Domain.Models.Queries.Category
{
    public class GetByIdCategoryQuery : IRequest<Response<CategoryDto>>
    {
        public GetByIdCategoryQuery(string id) { Id = id; }
        public string Id { get; set; }
    }
}
