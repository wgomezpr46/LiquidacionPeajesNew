using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class OficinaEntityConfiguration : IEntityTypeConfiguration<OficinaEntity>
    {
        public void Configure(EntityTypeBuilder<OficinaEntity> builder)
        {
            builder.ToTable("Ofi").HasKey(x => x.ID_Key);
        }
    }
}