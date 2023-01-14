using Microsoft.AspNetCore.Mvc;
using Example.Services.Catalog.Domain.Models.Queries.Course;
using Example.Shared.BaseApiController;
using Example.Services.Catalog.Domain.Models.Commands;

namespace Example.Services.Catalog.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CourseController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get() => CreateActionResultInstance(await Mediator.Send(new GetAllCourseQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) => CreateActionResultInstance(await Mediator.Send(new GetByIdCourseQuery(id)));

        [HttpPost]
        public async Task<IActionResult> Post(CreateCourseCommand command) => CreateActionResultInstance(await Mediator.Send(command));

    }
}
