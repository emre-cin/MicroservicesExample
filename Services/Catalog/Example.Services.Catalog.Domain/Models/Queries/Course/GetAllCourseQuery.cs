using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Shared.Dtos;
using MediatR;

namespace Example.Services.Catalog.Domain.Models.Queries.Course
{
    public class GetAllCourseQuery : IRequest<Response<List<CourseDto>>>
    {
    }
}
