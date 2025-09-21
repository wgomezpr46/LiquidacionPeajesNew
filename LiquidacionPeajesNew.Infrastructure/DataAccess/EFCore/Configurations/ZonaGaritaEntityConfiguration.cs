using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class ZonaGaritaEntityConfiguration : IEntityTypeConfiguration<ZonaGaritaEntity>
    {
        public void Configure(EntityTypeBuilder<ZonaGaritaEntity> builder)
        {
            builder.ToTable("tb_LPE_ZonaGarita").HasKey(x => x.IdZonaGarita);
            builder.Property(z => z.IdZonaGarita).ValueGeneratedOnAdd();
        }
    }
}