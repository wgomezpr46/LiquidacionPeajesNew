using LiquidacionPeajesNew.Application.Services.TipoDocumentoCompraService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TipoDocumentoCompraController : ControllerBase
    {
        private readonly ITipoDocumentoCompraService _service;

        public TipoDocumentoCompraController(ITipoDocumentoCompraService service)
        {
            _service = service;
        }

        // GET: api/TipoDocumentoCompra/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }
    }
}