using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    internal class OficinaEntityConfiguration : IEntityTypeConfiguration<OficinaEntity>
    {
        public void Configure(EntityTypeBuilder<OficinaEntity> builder)
        {
            builder.ToTable("Ofi").HasKey("ID_Key");
        }
    }
}