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
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, Response<List<CategoryDto>>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;
        public GetAllCategoryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = _repository.Get().ToList();
                if (categories == null || categories.Count == 0) return Response<List<CategoryDto>>.Fail("Not found any Category.", (int)HttpStatusCode.NotFound);

                return Response<List<CategoryDto>>.Success(_mapper.Map<List<Category>, List<CategoryDto>>(categories), (int)HttpStatusCode.OK);
            }
            catch
            {
                return Response<List<CategoryDto>>.Fail("An error occurred while get Categorys.", (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
