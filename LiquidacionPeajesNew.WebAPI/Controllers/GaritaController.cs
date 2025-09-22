using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.Services.GaritaService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GaritaController : ControllerBase
    {
        private readonly IGaritaService _garitaService;

        public GaritaController(IGaritaService garitaService)
        {
            _garitaService = garitaService;
        }

        // GET: api/Garita/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _garitaService.GetAllAsync();
            return Ok(response);
        }

        // ✅ GET: api/Garita/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var response = await _garitaService.GetByIdAsync(id);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        // ✅ POST: api/Garita/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GaritaRequest request)
        {
            var response = await _garitaService.AddAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ PUT: api/Garita/Update
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] GaritaRequest request)
        {
            var response = await _garitaService.UpdateAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ DELETE: api/Garita/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _garitaService.DeleteAsync(id);
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