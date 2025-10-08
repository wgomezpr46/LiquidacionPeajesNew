using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.Services.TarifarioGaritaService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TarifarioGaritaController : ControllerBase
    {
        private readonly ITarifarioGaritaService _service;

        public TarifarioGaritaController(ITarifarioGaritaService service)
        {
            _service = service;
        }

        /// Obtiene todos los tarifarios de las garitas.
        /// </summary>
        /// <returns>Lista de tarifarios de las garitas.</returns>
        /// <response code="200">Retorna la lista de tarifarios con éxito.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// GET: api/TarifarioGarita/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        /// Obtiene los detalles de un tarifario de garita por su ID.
        /// </summary>
        /// <param name="id">ID del tarifario de garita.</param>
        /// <returns>Detalles del tarifario de garita solicitado.</returns>
        /// <response code="200">Retorna los detalles del tarifario con éxito.</response>
        /// <response code="404">No se encontró el tarifario con el ID proporcionado.</response>
        /// ✅ GET: api/TarifarioGarita/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }

        /// Crea un nuevo tarifario de garita.
        /// </summary>
        /// <param name="request">Objeto que contiene la información del tarifario de garita a crear.</param>
        /// <returns>Resultado de la creación del tarifario.</returns>
        /// <response code="200">El tarifario fue creado con éxito.</response>
        /// <response code="400">Hubo un error en los datos proporcionados.</response>
        /// ✅ POST: api/TarifarioGarita/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TarifarioGaritaRequest request)
        {
            var response = await _service.AddAsync(request);
            return Ok(response);
        }

        /// Actualiza un tarifario de garita existente.
        /// </summary>
        /// <param name="request">Objeto que contiene la información actualizada del tarifario de garita.</param>
        /// <returns>Resultado de la actualización del tarifario.</returns>
        /// <response code="200">El tarifario fue actualizado con éxito.</response>
        /// <response code="400">Hubo un error en los datos proporcionados.</response>
        /// ✅ PUT: api/TarifarioGarita/Update/5
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] TarifarioGaritaRequest request)
        {
            var response = await _service.UpdateAsync(request);
            return Ok(response);
        }

        /// Elimina un tarifario de garita por su ID.
        /// </summary>
        /// <param name="id">ID del tarifario de garita a eliminar.</param>
        /// <returns>Resultado de la eliminación del tarifario.</returns>
        /// <response code="200">El tarifario fue eliminado con éxito.</response>
        /// <response code="404">No se encontró el tarifario con el ID proporcionado.</response>
        /// ✅ DELETE: api/TarifarioGarita/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}