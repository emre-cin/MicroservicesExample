using Example.Services.Catalog.Core.Mapper;
using Example.Services.Catalog.Core.Repository;
using Example.Services.Catalog.Domain.Models.Commands;
using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Services.Catalog.Domain.Models.Entities;
using Example.Services.Catalog.Domain.Models.Queries.Course;
using Example.Shared.Dtos;
using MediatR;
using System.Net;

namespace Example.Services.Catalog.Core.Services.CourseUseCases
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, Response<CourseDto>>
    {
        private readonly IRepository<Course> _repository;
        private readonly IMapper _mapper;
        public CreateCourseHandler(IRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<CourseDto>> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var course = await _repository.GetAsync(x => x.Name.ToLower() == command.Name.ToLower());
                if (course != null) return Response<CourseDto>.Fail("This course already exist.", (int)HttpStatusCode.NotFound);

                course = new(command);
                await _repository.AddAsync(course);

                return Response<CourseDto>.Success(_mapper.Map<Course, CourseDto>(course), (int)HttpStatusCode.OK);
            }
            catch
            {
                return Response<CourseDto>.Fail("An error occurred while get Courses.", (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
