using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class EstadoEntityConfiguration : IEntityTypeConfiguration<EstadoEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoEntity> builder)
        {
            builder.ToTable("tb_LPE_Estado").HasKey(x => x.IdEstado);
        }
    }
}