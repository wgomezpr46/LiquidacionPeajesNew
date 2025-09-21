using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BDALMContext _context;

        public UsuarioRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<UsuarioLoginEntity> GetByIdAsync(string codigo)
        {
            var usuarioLogin = new UsuarioLoginEntity();

            // Obtener la cadena de conexión del contexto
            var connectionString = _context.Database.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("usp_Usr_Login", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Usr_Codigo", SqlDbType.VarChar, 6)).Value = codigo ?? string.Empty;
                    command.Parameters.Add(new SqlParameter("@Usr_Nombre", SqlDbType.VarChar, 100)).Value = string.Empty;

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            usuarioLogin = new UsuarioLoginEntity
                            {
                                Usr_Codigo = reader["Usr_Codigo"] != DBNull.Value ? reader["Usr_Codigo"].ToString() : string.Empty,
                                Usr_Nombre = reader["Usr_Nombre"] != DBNull.Value ? reader["Usr_Nombre"].ToString() : string.Empty,
                                Usr_Password = reader["Usr_Password"] != DBNull.Value ? reader["Usr_Password"].ToString() : string.Empty,
                                Usr_Nivel = reader["Usr_Nivel"] != DBNull.Value ? reader["Usr_Nivel"].ToString() : string.Empty,
                                Usr_Estado = reader["Usr_Estado"] != DBNull.Value ? reader["Usr_Estado"].ToString() : string.Empty,
                                CODI_SUCURSAL = reader["CODI_SUCURSAL"] != DBNull.Value ? reader["CODI_SUCURSAL"].ToString() : string.Empty,
                                Ben_Codigo = reader["Ben_Codigo"] != DBNull.Value ? reader["Ben_Codigo"].ToString() : string.Empty,
                                TbPerfil_id = reader["TbPerfil_id"] != DBNull.Value ? Convert.ToInt32(reader["TbPerfil_id"]) : 0,
                                Ccosto = reader["Ccosto"] != DBNull.Value ? reader["Ccosto"].ToString() : string.Empty,
                                CodAux2 = reader["Aux2"] != DBNull.Value ? reader["Aux2"].ToString() : string.Empty,
                                CodAux3 = reader["Aux3"] != DBNull.Value ? reader["Aux3"].ToString() : string.Empty,
                                CodAux4 = reader["Aux4"] != DBNull.Value ? reader["Aux4"].ToString() : string.Empty,
                                Usr_CodEmp = reader["Usr_CodEmp"] != DBNull.Value ? reader["Usr_CodEmp"].ToString() : string.Empty,
                                Formato = reader["Formato"] != DBNull.Value ? Convert.ToInt32(reader["Formato"]) : 0,
                                Ofi_Codigo = reader["Ofi_Codigo"] != DBNull.Value ? reader["Ofi_Codigo"].ToString() : string.Empty,
                            };
                        }
                    }
                }
            }

            return usuarioLogin;
        }

        public async Task<UsuarioLoginEntity> GetByNameAsync(string nombre)
        {
            var usuarioLogin = new UsuarioLoginEntity();

            // Obtener la cadena de conexión del contexto
            var connectionString = _context.Database.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("usp_Usr_Login", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Usr_Codigo", SqlDbType.VarChar, 6)).Value = string.Empty;
                    command.Parameters.Add(new SqlParameter("@Usr_Nombre", SqlDbType.VarChar, 100)).Value = nombre ?? string.Empty;

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            usuarioLogin = new UsuarioLoginEntity
                            {
                                Usr_Codigo = reader["Usr_Codigo"] != DBNull.Value ? reader["Usr_Codigo"].ToString() : string.Empty,
                                Usr_Nombre = reader["Usr_Nombre"] != DBNull.Value ? reader["Usr_Nombre"].ToString() : string.Empty,
                                Usr_Password = reader["Usr_Password"] != DBNull.Value ? reader["Usr_Password"].ToString() : string.Empty,
                                Usr_Nivel = reader["Usr_Nivel"] != DBNull.Value ? reader["Usr_Nivel"].ToString() : string.Empty,
                                Usr_Estado = reader["Usr_Estado"] != DBNull.Value ? reader["Usr_Estado"].ToString() : string.Empty,
                                CODI_SUCURSAL = reader["CODI_SUCURSAL"] != DBNull.Value ? reader["CODI_SUCURSAL"].ToString() : string.Empty,
                                Ben_Codigo = reader["Ben_Codigo"] != DBNull.Value ? reader["Ben_Codigo"].ToString() : string.Empty,
                                TbPerfil_id = reader["TbPerfil_id"] != DBNull.Value ? Convert.ToInt32(reader["TbPerfil_id"]) : 0,
                                Ccosto = reader["Ccosto"] != DBNull.Value ? reader["Ccosto"].ToString() : string.Empty,
                                CodAux2 = reader["Aux2"] != DBNull.Value ? reader["Aux2"].ToString() : string.Empty,
                                CodAux3 = reader["Aux3"] != DBNull.Value ? reader["Aux3"].ToString() : string.Empty,
                                CodAux4 = reader["Aux4"] != DBNull.Value ? reader["Aux4"].ToString() : string.Empty,
                                Usr_CodEmp = reader["Usr_CodEmp"] != DBNull.Value ? reader["Usr_CodEmp"].ToString() : string.Empty,
                                Formato = reader["Formato"] != DBNull.Value ? Convert.ToInt32(reader["Formato"]) : 0,
                                Ofi_Codigo = reader["Ofi_Codigo"] != DBNull.Value ? reader["Ofi_Codigo"].ToString() : string.Empty,
                            };
                        }
                    }
                }
            }

            return usuarioLogin;
        }
    }
}