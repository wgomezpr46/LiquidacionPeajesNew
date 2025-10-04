using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class RutaEntityConfiguration : IEntityTypeConfiguration<RutaEntity>
    {
        public void Configure(EntityTypeBuilder<RutaEntity> builder)
        {
            builder.ToTable("tb_LPE_Ruta").HasKey(x => x.IdRuta);
            builder.Property(z => z.IdRuta).ValueGeneratedOnAdd();

            builder.HasOne(p => p.EstadoEntity).WithMany().HasForeignKey(p => p.IdEstado);
        }
    }
}