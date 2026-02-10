using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.Services.ModoPagoGaritaService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModoPagoGaritaController : ControllerBase
    {
        private readonly IModoPagoGaritaService _service;

        public ModoPagoGaritaController(IModoPagoGaritaService service)
        {
            _service = service;
        }

        /// Obtiene todos los modos de pago de las garitas.
        /// </summary>
        /// <returns>Lista de modos de pago.</returns>
        /// <response code="200">Retorna la lista de modos de pago con éxito.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// GET: api/ModoPagoGarita/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        /// Obtiene un modo de pago de garita por su ID.
        /// </summary>
        /// <param name="id">ID del modo de pago de la garita.</param>
        /// <returns>Modo de pago correspondiente al ID.</returns>
        /// <response code="200">Modo de pago encontrado con éxito.</response>
        /// <response code="404">No se encontró el modo de pago con ese ID.</response>
        /// ✅ GET: api/ModoPagoGarita/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(short id)
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }

        /// Crea un nuevo modo de pago para la garita.
        /// </summary>
        /// <param name="request">Datos del modo de pago a crear.</param>
        /// <returns>Resultado de la creación del modo de pago.</returns>
        /// <response code="200">Modo de pago creado con éxito.</response>
        /// <response code="400">Solicitud inválida o datos incorrectos.</response>
        /// ✅ POST: api/ModoPagoGarita/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ModoPagoGaritaRequest request)
        {
            var response = await _service.AddAsync(request);
            return Ok(response);
        }

        /// Actualiza un modo de pago de garita existente.
        /// </summary>
        /// <param name="request">Datos del modo de pago a actualizar.</param>
        /// <returns>Resultado de la actualización del modo de pago.</returns>
        /// <response code="200">Modo de pago actualizado con éxito.</response>
        /// <response code="400">Solicitud inválida o datos incorrectos.</response>
        /// ✅ PUT: api/ModoPagoGarita/Update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(short id, [FromBody] ModoPagoGaritaRequest request)
        {
            var response = await _service.UpdateAsync(request);
            return Ok(response);
        }

        /// Elimina un modo de pago de garita por su ID.
        /// </summary>
        /// <param name="id">ID del modo de pago a eliminar.</param>
        /// <returns>Resultado de la eliminación del modo de pago.</returns>
        /// <response code="200">Modo de pago eliminado con éxito.</response>
        /// <response code="404">No se encontró el modo de pago con ese ID.</response>
        /// ✅ DELETE: api/ModoPagoGarita/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}