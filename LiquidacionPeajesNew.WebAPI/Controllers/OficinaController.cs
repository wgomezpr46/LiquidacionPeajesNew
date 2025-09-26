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

        /// Obtiene todas las oficinas filtradas por el código de oficina.
        /// </summary>
        /// <param name="OfiCodigo">Código de la oficina para filtrar los resultados.</param>
        /// <returns>Lista de oficinas filtradas por el código de oficina.</returns>
        /// <response code="200">Retorna la lista de oficinas con éxito.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// GET: api/Oficina/GetAll?OfiCodigo=001
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string OfiCodigo)
        {
            var response = await _service.GetAllAsync(OfiCodigo);
            return Ok(response);
        }
    }
}