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
        private readonly IProveedorService _service;

        public ProveedorController(IProveedorService service)
        {
            _service = service;
        }

        /// Obtiene todos los proveedores disponibles.
        /// </summary>
        /// <returns>Lista de proveedores.</returns>
        /// <response code="200">Retorna la lista de proveedores con éxito.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// ✅ GET: api/Proveedor/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        /// Obtiene los detalles de un proveedor por su ID.
        /// </summary>
        /// <param name="id">ID del proveedor.</param>
        /// <returns>Detalles del proveedor solicitado.</returns>
        /// <response code="200">Retorna los detalles del proveedor con éxito.</response>
        /// <response code="404">No se encontró el proveedor con el ID proporcionado.</response>
        /// ✅ GET: api/Proveedor/GetById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
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

        /// Crea un nuevo proveedor.
        /// </summary>
        /// <param name="request">Objeto que contiene la información del proveedor a crear.</param>
        /// <returns>Resultado de la creación del proveedor.</returns>
        /// <response code="200">El proveedor fue creado con éxito.</response>
        /// <response code="400">Hubo un error en los datos proporcionados.</response>
        /// ✅ POST: api/Proveedor/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProveedorRequest request)
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

        /// Actualiza un proveedor existente.
        /// </summary>
        /// <param name="request">Objeto que contiene la información actualizada del proveedor.</param>
        /// <returns>Resultado de la actualización del proveedor.</returns>
        /// <response code="200">El proveedor fue actualizado con éxito.</response>
        /// <response code="400">Hubo un error en los datos proporcionados.</response>
        /// ✅ PUT: api/Proveedor/Update
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] ProveedorRequest request)
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

        /// Elimina un proveedor por su ID.
        /// </summary>
        /// <param name="id">ID del proveedor a eliminar.</param>
        /// <returns>Resultado de la eliminación del proveedor.</returns>
        /// <response code="200">El proveedor fue eliminado con éxito.</response>
        /// <response code="404">No se encontró el proveedor con el ID proporcionado.</response>
        /// ✅ DELETE: api/Proveedor/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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