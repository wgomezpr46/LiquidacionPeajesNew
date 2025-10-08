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
        private readonly IGaritaService _service;

        public GaritaController(IGaritaService service)
        {
            _service = service;
        }

        /// Obtiene todos los registros de garitas.
        /// </summary>
        /// <returns>Lista de garitas.</returns>
        /// <response code="200">Retorna la lista de garitas con éxito.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// ✅ GET: api/Garita/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        /// Obtiene los detalles de una garita por su ID.
        /// </summary>
        /// <param name="id">ID de la garita.</param>
        /// <returns>Detalles de la garita solicitada.</returns>
        /// <response code="200">Retorna los detalles de la garita con éxito.</response>
        /// <response code="404">No se encontró la garita con el ID proporcionado.</response>
        /// ✅ GET: api/Garita/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }

        /// Crea una nueva garita.
        /// </summary>
        /// <param name="request">Objeto que contiene la información de la garita a crear.</param>
        /// <returns>Resultado de la creación de la garita.</returns>
        /// <response code="200">La garita fue creada con éxito.</response>
        /// <response code="400">Hubo un error en los datos proporcionados.</response>
        /// ✅ POST: api/Garita/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GaritaRequest request)
        {
            var response = await _service.AddAsync(request);
            return Ok(response);
        }

        /// Actualiza una garita existente.
        /// </summary>
        /// <param name="request">Objeto que contiene la información actualizada de la garita.</param>
        /// <returns>Resultado de la actualización de la garita.</returns>
        /// <response code="200">La garita fue actualizada con éxito.</response>
        /// <response code="400">Hubo un error en los datos proporcionados.</response>
        /// ✅ PUT: api/Garita/Update
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] GaritaRequest request)
        {
            var response = await _service.UpdateAsync(request);
            return Ok(response);
        }

        /// Elimina una garita por su ID.
        /// </summary>
        /// <param name="id">ID de la garita a eliminar.</param>
        /// <returns>Resultado de la eliminación de la garita.</returns>
        /// <response code="200">La garita fue eliminada con éxito.</response>
        /// <response code="404">No se encontró la garita con el ID proporcionado.</response>
        /// ✅ DELETE: api/Garita/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}