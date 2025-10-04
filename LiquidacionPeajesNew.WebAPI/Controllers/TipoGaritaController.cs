using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.Services.TipoGaritaService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TipoGaritaController : ControllerBase
    {
        private readonly ITipoGaritaService _service;

        public TipoGaritaController(ITipoGaritaService service)
        {
            _service = service;
        }

        /// Obtiene todos los tipos de garitas disponibles.
        /// </summary>
        /// <returns>Lista de tipos de garitas.</returns>
        /// <response code="200">Retorna la lista de tipos de garitas con éxito.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// GET: api/TipoGarita/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        /// Obtiene los detalles de un tipo de garita por su ID.
        /// </summary>
        /// <param name="id">ID del tipo de garita.</param>
        /// <returns>Detalles del tipo de garita solicitado.</returns>
        /// <response code="200">Retorna los detalles del tipo de garita con éxito.</response>
        /// <response code="404">No se encontró el tipo de garita con el ID proporcionado.</response>
        /// ✅ GET: api/TipoGarita/GetById/5
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

        /// Crea un nuevo tipo de garita.
        /// </summary>
        /// <param name="request">Objeto que contiene la información del tipo de garita a crear.</param>
        /// <returns>Resultado de la creación del tipo de garita.</returns>
        /// <response code="200">El tipo de garita fue creado con éxito.</response>
        /// <response code="400">Hubo un error en los datos proporcionados.</response>
        /// ✅ POST: api/TipoGarita/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoGaritaRequest request)
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

        /// Actualiza un tipo de garita existente.
        /// </summary>
        /// <param name="request">Objeto que contiene la información actualizada del tipo de garita.</param>
        /// <returns>Resultado de la actualización del tipo de garita.</returns>
        /// <response code="200">El tipo de garita fue actualizado con éxito.</response>
        /// <response code="400">Hubo un error en los datos proporcionados.</response>
        /// ✅ PUT: api/TipoGarita/Update
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] TipoGaritaRequest request)
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

        /// Elimina un tipo de garita por su ID.
        /// </summary>
        /// <param name="id">ID del tipo de garita a eliminar.</param>
        /// <returns>Resultado de la eliminación del tipo de garita.</returns>
        /// <response code="200">El tipo de garita fue eliminado con éxito.</response>
        /// <response code="404">No se encontró el tipo de garita con el ID proporcionado.</response>
        /// ✅ DELETE: api/TipoGarita/Delete/5
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