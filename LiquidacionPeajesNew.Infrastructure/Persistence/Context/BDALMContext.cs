using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Context
{
    public class BDALMContext : DbContext
    {
        // 1. DbSet properties
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ErrorLogEntity> ErrorLogs { get; set; }

        // 2. Constructor
        public BDALMContext(DbContextOptions<BDALMContext> options) : base(options) { }

        // 3. OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ErrorLogEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}