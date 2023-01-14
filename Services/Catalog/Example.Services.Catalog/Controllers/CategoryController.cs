using Microsoft.AspNetCore.Mvc;
using Example.Shared.BaseApiController;
using Example.Services.Catalog.Domain.Models.Queries.Category;
using Example.Services.Catalog.Domain.Models.Commands;

namespace Example.Services.Catalog.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CategoryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get() => CreateActionResultInstance(await Mediator.Send(new GetAllCategoryQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) => CreateActionResultInstance(await Mediator.Send(new GetByIdCategoryQuery(id)));

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommand command) => CreateActionResultInstance(await Mediator.Send(command));

    }
}
