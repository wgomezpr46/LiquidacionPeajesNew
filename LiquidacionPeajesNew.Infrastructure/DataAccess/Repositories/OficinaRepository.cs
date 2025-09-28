using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
                                Ofi_Codigo = reader["Ofi_Codigo"] != DBNull.Value ? reader["Ofi_Codigo"].ToString() : string.Empty,
                                Usr_Codigo = reader["Usr_Codigo"] != DBNull.Value ? reader["Usr_Codigo"].ToString() : string.Empty,
                                Ofi_Nombre = reader["Ofi_Nombre"] != DBNull.Value ? reader["Ofi_Nombre"].ToString() : string.Empty,
                                Ofi_Direccion = reader["Ofi_Direccion"] != DBNull.Value ? reader["Ofi_Direccion"].ToString() : string.Empty,
                                Ofi_Telefono1 = reader["Ofi_Telefono1"] != DBNull.Value ? reader["Ofi_Telefono1"].ToString() : string.Empty,
                                Ofi_Telefono2 = reader["Ofi_Telefono2"] != DBNull.Value ? reader["Ofi_Telefono2"].ToString() : string.Empty,
                                Ofi_EMail = reader["Ofi_EMail"] != DBNull.Value ? reader["Ofi_EMail"].ToString() : string.Empty,
                                Ofi_Fecha = reader["Ofi_Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Ofi_Fecha"]) : (DateTime?)null,
                                Ofi_Hora = reader["Ofi_Hora"] != DBNull.Value ? reader["Ofi_Hora"].ToString() : string.Empty,
                                Ofi_Estado = reader["Ofi_Estado"] != DBNull.Value ? reader["Ofi_Estado"].ToString() : string.Empty,
                                Suc_Codigo = reader["Suc_Codigo"] != DBNull.Value ? reader["Suc_Codigo"].ToString() : string.Empty,
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