
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WilmfebAPI.DTOModels;

using WilmfebAPI.Services.IServices;

namespace WilmfebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserSignIn userSignIn)
        {
            return  _userService.RegisterNewUser(userSignIn);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserSignIn userSignIn)
        {
            return _userService.AuthenticateUser(userSignIn);
        }
    }
}