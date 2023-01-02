using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Shared.Dtos;
using MediatR;

namespace Example.Services.Catalog.Domain.Models.Queries.Course
{
    public class GetByIdQuery : IRequest<Response<CourseDto>>
    {
        public GetByIdQuery(string id) { Id = id; }
        public string Id { get; set; }
    }
}
