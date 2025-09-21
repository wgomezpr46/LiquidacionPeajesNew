using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.Services.ProveedorService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService service)
        {
            _proveedorService = service;
        }

        // ✅ GET: api/Proveedor/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _proveedorService.GetAllAsync();
            return Ok(response);
        }

        // ✅ GET: api/Proveedor/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _proveedorService.GetByIdAsync(id);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        // ✅ POST: api/Proveedor/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProveedorRequest request)
        {
            var response = await _proveedorService.AddAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ PUT: api/Proveedor/Update/5
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] ProveedorRequest request)
        {
            var response = await _proveedorService.UpdateAsync(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // ✅ DELETE: api/Proveedor/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _proveedorService.DeleteAsync(id);
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