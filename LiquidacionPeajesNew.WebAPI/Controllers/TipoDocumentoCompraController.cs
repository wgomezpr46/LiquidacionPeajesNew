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

        /// Obtiene todos los tipos de documentos de compra disponibles.
        /// </summary>
        /// <returns>Lista de tipos de documentos de compra.</returns>
        /// <response code="200">Retorna la lista de tipos de documentos de compra con éxito.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// GET: api/TipoDocumentoCompra/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }
    }
}