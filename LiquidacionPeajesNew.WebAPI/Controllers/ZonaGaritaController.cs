using LiquidacionPeajesNew.Application.DTOs.Requests;
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

        // ✅ GET: api/ZonaGarita/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(byte id)
        {
            var response = await _zonaGaritaService.GetByIdAsync(id);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        // ✅ POST: api/ZonaGarita/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ZonaGaritaRequest request)
        {
            var response = await _zonaGaritaService.AddAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ PUT: api/ZonaGarita/Update/5
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] ZonaGaritaRequest request)
        {
            var response = await _zonaGaritaService.UpdateAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ DELETE: api/ZonaGarita/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
            var response = await _zonaGaritaService.DeleteAsync(id);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }
    }
}