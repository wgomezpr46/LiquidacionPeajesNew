using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    internal class ProveedorEntityConfiguration : IEntityTypeConfiguration<ProveedorEntity>
    {
        public void Configure(EntityTypeBuilder<ProveedorEntity> builder)
        {
            builder.ToTable("tb_LPE_Proveedor").HasKey(x => x.IdProveedorGarita);
            builder.Property(z => z.IdProveedorGarita).ValueGeneratedOnAdd();
            builder.HasOne(p => p.TipoDocumentoCompra).WithMany().HasForeignKey(p => p.IdTipoDocEmite).HasConstraintName("FK_tb_LPE_Proveedor_tb_LPE_TipoDocumentoCompra");
        }
    }
}