using Microsoft.AspNetCore.Mvc;
using Example.Services.Catalog.Domain.Models.Queries.Course;
using Example.Shared.BaseApiController;

namespace Example.Services.Catalog.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CourseController : BaseApiController
    {
        //private readonly IRepository<Course> _repository;

        //public CourseController(IRepository<Course> repository)
        //{
        //    _repository = repository;
        //}

        [HttpGet]
        public async Task<IActionResult> GetById(string id) => CreateActionResultInstance(await Mediator.Send(new GetByIdQuery(id)));
    }
}
