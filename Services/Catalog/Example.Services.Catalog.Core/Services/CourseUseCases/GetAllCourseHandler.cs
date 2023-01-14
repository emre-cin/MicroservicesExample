using Example.Services.Catalog.Core.Mapper;
using Example.Services.Catalog.Core.Repository;
using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Services.Catalog.Domain.Models.Entities;
using Example.Services.Catalog.Domain.Models.Queries.Course;
using Example.Shared.Dtos;
using MediatR;
using System.Net;

namespace Example.Services.Catalog.Core.Services.CourseUseCases
{
    public class GetAllCourseHandler : IRequestHandler<GetAllCourseQuery, Response<List<CourseDto>>>
    {
        private readonly IRepository<Course> _repository;
        private readonly IMapper _mapper;
        public GetAllCourseHandler(IRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<CourseDto>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var courses = _repository.Get().ToList();
                if (courses == null || courses.Count == 0) return Response<List<CourseDto>>.Fail("Not found any course.", (int)HttpStatusCode.NotFound);

                return Response<List<CourseDto>>.Success(_mapper.Map<List<Course>, List<CourseDto>>(courses), (int)HttpStatusCode.OK);
            }
            catch
            {
                return Response<List<CourseDto>>.Fail("An error occurred while get Courses.", (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
