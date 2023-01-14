using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Shared.Dtos;
using MediatR;

namespace Example.Services.Catalog.Domain.Models.Queries.Category
{
    public class GetAllCategoryQuery : IRequest<Response<List<CategoryDto>>>
    {
    }
}
