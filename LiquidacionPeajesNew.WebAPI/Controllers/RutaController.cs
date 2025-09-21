using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.Services.RutaService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        private readonly IRutaService _rutaService;

        public RutaController(IRutaService rutaService)
        {
            _rutaService = rutaService;
        }

        // ✅ GET: api/ruta/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _rutaService.GetAllAsync();
            return Ok(response);
        }

        // ✅ GET: api/ruta/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _rutaService.GetByIdAsync(id);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        // ✅ POST: api/ruta/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RutaRequest request)
        {
            var response = await _rutaService.AddAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ PUT: api/ruta/Update/5
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] RutaRequest request)
        {
            var response = await _rutaService.UpdateAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ DELETE: api/ruta/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _rutaService.DeleteAsync(id);
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