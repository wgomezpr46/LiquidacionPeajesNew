using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.Services.ModoPagoGaritaService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModoPagoGaritaController : ControllerBase
    {
        private readonly IModoPagoGaritaService _service;

        public ModoPagoGaritaController(IModoPagoGaritaService service)
        {
            _service = service;
        }

        // GET: api/ModoPagoGarita/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        // ✅ GET: api/ModoPagoGarita/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(short id)
        {
            var response = await _service.GetByIdAsync(id);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        // ✅ POST: api/ModoPagoGarita/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ModoPagoGaritaRequest request)
        {
            var response = await _service.AddAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ PUT: api/ModoPagoGarita/Update/5
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] ModoPagoGaritaRequest request)
        {
            var response = await _service.UpdateAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ DELETE: api/ModoPagoGarita/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            var response = await _service.DeleteAsync(id);
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