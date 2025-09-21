using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class TipoDocumentoCompraEntityConfiguration : IEntityTypeConfiguration<TipoDocumentoCompraEntity>
    {
        public void Configure(EntityTypeBuilder<TipoDocumentoCompraEntity> builder)
        {
            builder.ToTable("tb_LPE_TipoDocumentoCompra").HasKey(x => x.IdTipoDoc);
        }
    }
}