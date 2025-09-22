using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class GaritaEntityConfiguration : IEntityTypeConfiguration<GaritaEntity>
    {
        public void Configure(EntityTypeBuilder<GaritaEntity> builder)
        {
            builder.ToTable("tb_LPE_Garita").HasKey(x => x.IdGarita);
            builder.Property(z => z.IdGarita).ValueGeneratedOnAdd();
            builder.Property(z => z.MontoEjeVehLigero).HasPrecision(18, 2);
            builder.Property(z => z.MontoEjeVehPesado).HasPrecision(18, 2);

            builder.HasOne(p => p.ZonaGaritaEntity).WithMany().HasForeignKey(p => p.IdZonaGarita);
            builder.HasOne(p => p.TipoGaritaEntity).WithMany().HasForeignKey(p => p.IdTipoGarita);
            builder.HasOne(p => p.EstadoEntity).WithMany().HasForeignKey(p => p.IdEstado);
        }
    }
}