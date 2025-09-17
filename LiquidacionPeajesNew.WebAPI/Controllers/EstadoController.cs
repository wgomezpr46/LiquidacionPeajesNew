using LiquidacionPeajesNew.Application.Services.EstadoService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _service;

        public EstadoController(IEstadoService service)
        {
            _service = service;
        }

        // GET: api/Estado/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }
    }
}