using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Configurations
{
    internal class EstadoEntityConfiguration : IEntityTypeConfiguration<EstadoEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoEntity> builder)
        {
            builder.ToTable("tb_LPE_Estado").HasKey("IdEstado");
        }
    }
}