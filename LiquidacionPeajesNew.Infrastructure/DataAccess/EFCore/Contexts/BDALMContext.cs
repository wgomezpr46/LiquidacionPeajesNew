using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts
{
    public class BDALMContext : DbContext
    {
        // 1. DbSet properties
        public DbSet<ErrorLogEntity> ErrorLogs { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RutaEntity> Rutas { get; set; }
        public DbSet<OficinaEntity> Oficinas { get; set; }
        public DbSet<EstadoEntity> Estados { get; set; }
        public DbSet<ZonaGaritaEntity> ZonaGaritas { get; set; }
        public DbSet<TipoDocumentoCompraEntity> TipoDocumentoCompras { get; set; }

        // 2. Constructor
        public BDALMContext(DbContextOptions<BDALMContext> options) : base(options) { }

        // 3. OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ErrorLogEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RutaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OficinaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ZonaGaritaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TipoDocumentoCompraEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}