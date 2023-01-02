using Example.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Shared.BaseApiController
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        private ISender _mediatr;
        protected ISender Mediator => _mediatr ??= HttpContext.RequestServices.GetService<ISender>();

        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
