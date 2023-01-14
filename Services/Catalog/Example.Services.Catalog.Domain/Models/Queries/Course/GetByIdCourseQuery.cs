using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Shared.Dtos;
using MediatR;

namespace Example.Services.Catalog.Domain.Models.Queries.Course
{
    public class GetByIdCourseQuery : IRequest<Response<CourseDto>>
    {
        public GetByIdCourseQuery(string id) { Id = id; }
        public string Id { get; set; }
    }
}
