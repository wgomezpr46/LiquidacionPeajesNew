using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Initializers
{
    public static class DatabaseInitializer
    {
        public static async Task InitializeAsync(DbContext context)
        {
            try
            {
                if (context.Database.GetDbConnection().State != System.Data.ConnectionState.Open)
                {
                    await context.Database.OpenConnectionAsync();
                }

                await EnsureErrorLogsTableExistsAsync(context);
                // Here you can add more validations or scripts in the future.

            }
            catch (Exception ex)
            {
                // Loguea aquí con tu servicio de logs o simplemente lanza el error con mensaje adicional
                throw new Exception("Error al inicializar la tabla de logs.", ex);
            }
        }

        public static async Task EnsureErrorLogsTableExistsAsync(DbContext context)
        {
            var sql = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tb_ErrorLogs')
                    BEGIN
                        CREATE TABLE tb_ErrorLogs (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            UserId VARCHAR(100) NULL,
                            Message VARCHAR(MAX) NOT NULL,
                            StackTrace VARCHAR(MAX) NULL,
                            Source VARCHAR(500) NULL,
                            InnerException VARCHAR(MAX) NULL,
                            RequestPath VARCHAR(500) NULL,
                            RequestMethod VARCHAR(20) NULL,
                            RequestParameters VARCHAR(MAX) NULL,
                            RequestHeaders VARCHAR(MAX) NULL,
                            RequestBody VARCHAR(MAX) NULL,
                            CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE()
                        );
                    END

                    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_tb_ErrorLogs_UserId' AND object_id = OBJECT_ID('tb_ErrorLogs'))
                    BEGIN
                        CREATE INDEX IX_tb_ErrorLogs_UserId ON tb_ErrorLogs(UserId);
                    END

                    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_tb_ErrorLogs_CreatedAt' AND object_id = OBJECT_ID('tb_ErrorLogs'))
                    BEGIN
                        CREATE INDEX IX_tb_ErrorLogs_CreatedAt ON tb_ErrorLogs(CreatedAt);
                    END

                    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_tb_ErrorLogs_RequestMethod' AND object_id = OBJECT_ID('tb_ErrorLogs'))
                    BEGIN
                        CREATE INDEX IX_tb_ErrorLogs_RequestMethod ON tb_ErrorLogs(RequestMethod);
                    END

                    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_tb_ErrorLogs_UserId_CreatedAt' AND object_id = OBJECT_ID('tb_ErrorLogs'))
                    BEGIN
                        CREATE INDEX IX_tb_ErrorLogs_UserId_CreatedAt ON tb_ErrorLogs(UserId, CreatedAt);
                    END
                ";

            await context.Database.ExecuteSqlRawAsync(sql);
        }
    }
}