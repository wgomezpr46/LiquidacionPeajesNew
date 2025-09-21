using LiquidacionPeajesNew.Application.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetById(string code)
        {
            var response = await _userService.GetByIdAsync(code);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}