using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Shared.Dtos;
using MediatR;

namespace Example.Services.Catalog.Domain.Models.Commands
{
    public class CreateCourseCommand : IRequest<Response<CourseDto>>
    {
        public string UserId { get; set; }

        public string CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}
