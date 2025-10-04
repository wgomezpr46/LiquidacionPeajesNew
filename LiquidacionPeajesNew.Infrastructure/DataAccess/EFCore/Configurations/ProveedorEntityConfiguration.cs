using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class ProveedorEntityConfiguration : IEntityTypeConfiguration<ProveedorEntity>
    {
        public void Configure(EntityTypeBuilder<ProveedorEntity> builder)
        {
            builder.ToTable("tb_LPE_Proveedor").HasKey(x => x.IdProveedorGarita);
            builder.Property(z => z.IdProveedorGarita).ValueGeneratedOnAdd();

            builder.HasOne(p => p.TipoDocumentoCompraEntity).WithMany().HasForeignKey(p => p.IdTipoDocEmite);
            builder.HasOne(p => p.EstadoEntity).WithMany().HasForeignKey(p => p.IdEstado);
        }
    }
}