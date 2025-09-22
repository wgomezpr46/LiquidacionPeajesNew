using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.Services.TipoGaritaService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TipoGaritaController : ControllerBase
    {
        private readonly ITipoGaritaService _tipoGaritaService;

        public TipoGaritaController(ITipoGaritaService zonaGaritaService)
        {
            _tipoGaritaService = zonaGaritaService;
        }

        // GET: api/TipoGarita/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _tipoGaritaService.GetAllAsync();
            return Ok(response);
        }

        // ✅ GET: api/TipoGarita/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(short id)
        {
            var response = await _tipoGaritaService.GetByIdAsync(id);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        // ✅ POST: api/TipoGarita/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoGaritaRequest request)
        {
            var response = await _tipoGaritaService.AddAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ PUT: api/TipoGarita/Update
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] TipoGaritaRequest request)
        {
            var response = await _tipoGaritaService.UpdateAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ DELETE: api/TipoGarita/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            var response = await _tipoGaritaService.DeleteAsync(id);
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