using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class TarifarioGaritaEntityConfiguration : IEntityTypeConfiguration<TarifarioGaritaEntity>
    {
        public void Configure(EntityTypeBuilder<TarifarioGaritaEntity> builder)
        {
            builder.ToTable("tb_LPE_TarifarioGaritas").HasKey(x => x.IdTarifarioGarita);
            builder.Property(z => z.IdTarifarioGarita).ValueGeneratedOnAdd();

            builder.HasOne(p => p.GaritaEntity).WithMany().HasForeignKey(p => p.IdGarita);

            builder.Property(t => t.IGV).HasPrecision(18, 2);
            builder.Property(t => t.Tarifa).HasPrecision(18, 2);
            builder.Property(t => t.ValorVenta).HasPrecision(18, 2);
        }
    }
}