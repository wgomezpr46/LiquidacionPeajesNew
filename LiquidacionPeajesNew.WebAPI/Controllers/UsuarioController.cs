using LiquidacionPeajesNew.Application.Services.UsuarioService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        // GET: api/Usuario/GetById/0001
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetById(string codigo)
        {
            var response = await _service.GetByIdAsync(codigo);
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