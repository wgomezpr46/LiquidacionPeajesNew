using LiquidacionPeajesNew.Application.Services.UsuarioService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _userService;

        public UsuarioController(IUsuarioService userService)
        {
            _userService = userService;
        }

        // GET: api/Usuario/GetById/0001
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