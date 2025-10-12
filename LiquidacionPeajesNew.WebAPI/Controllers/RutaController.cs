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
        private readonly IRutaService _service;

        public RutaController(IRutaService service)
        {
            _service = service;
        }

        /// Obtiene todas las rutas disponibles.
        /// </summary>
        /// <returns>Lista de rutas.</returns>
        /// <response code="200">Retorna la lista de rutas con éxito.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// ✅ GET: api/Ruta/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        /// Obtiene los detalles de una ruta por su ID.
        /// </summary>
        /// <param name="id">ID de la ruta.</param>
        /// <returns>Detalles de la ruta solicitada.</returns>
        /// <response code="200">Retorna los detalles de la ruta con éxito.</response>
        /// <response code="404">No se encontró la ruta con el ID proporcionado.</response>
        /// ✅ GET: api/Ruta/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }

        /// Crea una nueva ruta.
        /// </summary>
        /// <param name="request">Objeto que contiene la información de la ruta a crear.</param>
        /// <returns>Resultado de la creación de la ruta.</returns>
        /// <response code="200">La ruta fue creada con éxito.</response>
        /// <response code="400">Hubo un error en los datos proporcionados.</response>
        /// ✅ POST: api/Ruta/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RutaRequest request)
        {
            var response = await _service.AddAsync(request);
            return Ok(response);
        }

        /// Actualiza una ruta existente.
        /// </summary>
        /// <param name="request">Objeto que contiene la información actualizada de la ruta.</param>
        /// <returns>Resultado de la actualización de la ruta.</returns>
        /// <response code="200">La ruta fue actualizada con éxito.</response>
        /// <response code="400">Hubo un error en los datos proporcionados.</response>
        /// ✅ PUT: api/Ruta/Update/5
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] RutaRequest request)
        {
            var response = await _service.UpdateAsync(request);
            return Ok(response);
        }

        /// Elimina una ruta por su ID.
        /// </summary>
        /// <param name="id">ID de la ruta a eliminar.</param>
        /// <returns>Resultado de la eliminación de la ruta.</returns>
        /// <response code="200">La ruta fue eliminada con éxito.</response>
        /// <response code="404">No se encontró la ruta con el ID proporcionado.</response>
        /// ✅ DELETE: api/Ruta/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}