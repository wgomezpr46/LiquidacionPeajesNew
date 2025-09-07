using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Context
{
    public class BDALMContext : DbContext
    {
        // 1. DbSet properties
        public DbSet<UserEntity> Users { get; set; }

        // 2. Constructor
        public BDALMContext(DbContextOptions<BDALMContext> options) : base(options) { }

        // 3. OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("tb_Usuario").HasKey("IdUsuario");

            base.OnModelCreating(modelBuilder);
        }
    }
}