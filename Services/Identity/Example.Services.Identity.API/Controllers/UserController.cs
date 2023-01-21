using Example.Services.Identity.API.Dtos;
using Example.Services.Identity.API.Models;
using Example.Shared.BaseApiController;
using Example.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Example.Services.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignUpDto signUpDto)
        {
            ApplicationUser user = new() { UserName = signUpDto.UserName, Email = signUpDto.Email, City = signUpDto.City };

            var result = await _userManager.CreateAsync(user, signUpDto.Password);

            if (result.Succeeded)
                return NoContent();
            else
                return CreateActionResultInstance(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
        }
    }
}
