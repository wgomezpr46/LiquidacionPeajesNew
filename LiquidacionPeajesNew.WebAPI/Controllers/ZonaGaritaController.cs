using LiquidacionPeajesNew.Application.Services.ZonaGaritaService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ZonaGaritaController : ControllerBase
    {
        private readonly IZonaGaritaService _zonaGaritaService;

        public ZonaGaritaController(IZonaGaritaService zonaGaritaService)
        {
            _zonaGaritaService = zonaGaritaService;
        }

        // GET: api/ZonaGarita/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _zonaGaritaService.GetAllAsync();
            return Ok(response);
        }
    }
}