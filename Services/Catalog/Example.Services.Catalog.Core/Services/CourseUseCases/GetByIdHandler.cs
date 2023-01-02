using Example.Services.Catalog.Core.Repository;
using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Services.Catalog.Domain.Models.Entities;
using Example.Services.Catalog.Domain.Models.Queries.Course;
using Example.Shared.Dtos;
using MediatR;
using System.Net;

namespace Example.Services.Catalog.Core.Services.CourseUseCases
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, Response<CourseDto>>
    {
        private readonly IRepository<Course> _repository;

        public GetByIdHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<Response<CourseDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var course = _repository.GetByIdAsync(request.Id);
                if (course == null) return Response<CourseDto>.Fail("Course not found.", (int)HttpStatusCode.NotFound);
                return Response<CourseDto>.Success(new CourseDto() { Name = "Test emre"}, (int)HttpStatusCode.OK);
            }
            catch { return Response<CourseDto>.Fail("An error occurred while get Course.", (int)HttpStatusCode.InternalServerError);}
        }
    }
}
