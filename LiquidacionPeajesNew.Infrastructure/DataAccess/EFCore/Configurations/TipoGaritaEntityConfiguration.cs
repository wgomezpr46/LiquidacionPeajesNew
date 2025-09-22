using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class TipoGaritaEntityConfiguration : IEntityTypeConfiguration<TipoGaritaEntity>
    {
        public void Configure(EntityTypeBuilder<TipoGaritaEntity> builder)
        {
            builder.ToTable("tb_LPE_TipoGarita").HasKey(x => x.IdTipoGarita);
            builder.Property(z => z.IdTipoGarita).ValueGeneratedOnAdd();

            builder.HasOne(p => p.ModoPagoGaritaEntity).WithMany().HasForeignKey(p => p.IdModoPagoGarita);
            builder.HasOne(p => p.EstadoEntity).WithMany().HasForeignKey(p => p.IdEstado);
        }
    }
}