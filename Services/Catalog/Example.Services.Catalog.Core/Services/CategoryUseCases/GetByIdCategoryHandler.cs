using Example.Services.Catalog.Core.Mapper;
using Example.Services.Catalog.Core.Repository;
using Example.Services.Catalog.Domain.Models.Dtos;
using Example.Services.Catalog.Domain.Models.Entities;
using Example.Services.Catalog.Domain.Models.Queries.Category;
using Example.Shared.Dtos;
using MediatR;
using System.Net;

namespace Example.Services.Catalog.Core.Services.CategoryUseCases
{
    public class GetByIdCategoryHandler : IRequestHandler<GetByIdCategoryQuery, Response<CategoryDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;
        public GetByIdCategoryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<CategoryDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _repository.GetByIdAsync(request.Id);
                if (category == null) return Response<CategoryDto>.Fail("Category not found.", (int)HttpStatusCode.NotFound);

                return Response<CategoryDto>.Success(_mapper.Map<Category, CategoryDto>(category), (int)HttpStatusCode.OK);
            }
            catch
            {
                return Response<CategoryDto>.Fail("An error occurred while get Category.", (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
