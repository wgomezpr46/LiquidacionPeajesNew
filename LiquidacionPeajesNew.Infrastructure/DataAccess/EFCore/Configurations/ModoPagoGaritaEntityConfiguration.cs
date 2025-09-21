using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class ModoPagoGaritaEntityConfiguration : IEntityTypeConfiguration<ModoPagoGaritaEntity>
    {
        public void Configure(EntityTypeBuilder<ModoPagoGaritaEntity> builder)
        {
            builder.ToTable("tb_LPE_ModoPagoGarita").HasKey(x => x.IdModoPagoGarita);
            builder.Property(z => z.IdModoPagoGarita).ValueGeneratedOnAdd();

            builder.HasOne(p => p.EstadoEntity).WithMany().HasForeignKey(p => p.IdEstado);
        }
    }
}