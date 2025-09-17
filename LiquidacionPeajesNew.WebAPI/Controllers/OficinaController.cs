using LiquidacionPeajesNew.Application.Services.OficinaService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OficinaController : ControllerBase
    {
        private readonly IOficinaService _service;

        public OficinaController(IOficinaService service)
        {
            _service = service;
        }

        // GET: api/Oficina/GetAll?OfiCodigo=001
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string OfiCodigo)
        {
            var response = await _service.GetAllAsync(OfiCodigo);
            return Ok(response);
        }
    }
}