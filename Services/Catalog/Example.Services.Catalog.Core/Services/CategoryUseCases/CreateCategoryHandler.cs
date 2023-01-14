using Example.Services.Catalog.Core.Mapper;
using Example.Services.Catalog.Core.Repository;
using Example.Services.Catalog.Domain.Models.Commands;
using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Services.Catalog.Domain.Models.Entities;
using Example.Services.Catalog.Domain.Models.Queries.Category;
using Example.Shared.Dtos;
using MediatR;
using System.Net;

namespace Example.Services.Catalog.Core.Services.CategoryUseCases
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Response<CategoryDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;
        public CreateCategoryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<CategoryDto>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _repository.GetAsync(x => x.Name.ToLower() == command.Name.ToLower());
                if (category != null) return Response<CategoryDto>.Fail("This Category already exist.", (int)HttpStatusCode.NotFound);

                category = new(command);
                await _repository.AddAsync(category);

                return Response<CategoryDto>.Success(_mapper.Map<Category, CategoryDto>(category), (int)HttpStatusCode.OK);
            }
            catch
            {
                return Response<CategoryDto>.Fail("An error occurred while get Categorys.", (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
