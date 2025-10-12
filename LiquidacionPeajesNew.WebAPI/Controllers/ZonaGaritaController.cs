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
        private readonly IZonaGaritaService _service;

        public ZonaGaritaController(IZonaGaritaService service)
        {
            _service = service;
        }

        /// Obtiene todas las zonas de garitas disponibles.
        /// </summary>
        /// <returns>Lista de zonas de garitas.</returns>
        /// <response code="200">Retorna la lista de zonas de garitas con éxito.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// GET: api/ZonaGarita/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        /// Obtiene los detalles de una zona de garita por su ID.
        /// </summary>
        /// <param name="id">ID de la zona de garita.</param>
        /// <returns>Detalles de la zona de garita solicitada.</returns>
        /// <response code="200">Retorna los detalles de la zona de garita con éxito.</response>
        /// <response code="404">No se encontró la zona de garita con el ID proporcionado.</response>
        /// ✅ GET: api/ZonaGarita/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(short id)
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }

        /// Crea una nueva zona de garita.
        /// </summary>
        /// <param name="request">Objeto que contiene la información de la zona de garita a crear.</param>
        /// <returns>Resultado de la creación de la zona de garita.</returns>
        /// <response code="200">La zona de garita fue creada con éxito.</response>
        /// <response code="400">Hubo un error con los datos proporcionados.</response>
        /// ✅ POST: api/ZonaGarita/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ZonaGaritaRequest request)
        {
            var response = await _service.AddAsync(request);
            return Ok(response);
        }

        /// Actualiza una zona de garita existente.
        /// </summary>
        /// <param name="request">Objeto que contiene la información actualizada de la zona de garita.</param>
        /// <returns>Resultado de la actualización de la zona de garita.</returns>
        /// <response code="200">La zona de garita fue actualizada con éxito.</response>
        /// <response code="400">Hubo un error con los datos proporcionados.</response>
        /// ✅ PUT: api/ZonaGarita/Update/5
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] ZonaGaritaRequest request)
        {
            var response = await _service.UpdateAsync(request);
            return Ok(response);
        }

        /// Elimina una zona de garita por su ID.
        /// </summary>
        /// <param name="id">ID de la zona de garita a eliminar.</param>
        /// <returns>Resultado de la eliminación de la zona de garita.</returns>
        /// <response code="200">La zona de garita fue eliminada con éxito.</response>
        /// <response code="404">No se encontró la zona de garita con el ID proporcionado.</response>
        /// ✅ DELETE: api/ZonaGarita/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}