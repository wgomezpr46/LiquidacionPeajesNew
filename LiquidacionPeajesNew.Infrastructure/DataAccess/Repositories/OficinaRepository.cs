using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
{
    public class OficinaRepository : IOficinaRepository
    {
        private readonly BDALMContext _context;

        public OficinaRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OficinaEntity>> GetAllAsync(string OfiCodigo)
        {
            var oficinas = new List<OficinaEntity>();

            // Obtener la cadena de conexión del contexto
            var connectionString = _context.Database.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("usp_Ofi_Select_Activas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Ofi_Codigo", SqlDbType.VarChar, 3)).Value = OfiCodigo ?? string.Empty;

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var oficina = new OficinaEntity
                            {
                                Ofi_Codigo = reader["Ofi_Codigo"]?.ToString(),
                                Usr_Codigo = reader["Usr_Codigo"]?.ToString(),
                                Ofi_Nombre = reader["Ofi_Nombre"]?.ToString(),
                                Ofi_Direccion = reader["Ofi_Direccion"]?.ToString(),
                                Ofi_Telefono1 = reader["Ofi_Telefono1"]?.ToString(),
                                Ofi_Telefono2 = reader["Ofi_Telefono2"]?.ToString(),
                                Ofi_EMail = reader["Ofi_EMail"]?.ToString(),
                                Ofi_Fecha = reader["Ofi_Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Ofi_Fecha"]) : default,
                                Ofi_Hora = reader["Ofi_Hora"]?.ToString(),
                                Ofi_Estado = reader["Ofi_Estado"]?.ToString(),
                                Suc_Codigo = reader["Suc_Codigo"]?.ToString()
                            };

                            oficinas.Add(oficina);
                        }
                    }
                }
            }

            return oficinas;
        }
    }
}