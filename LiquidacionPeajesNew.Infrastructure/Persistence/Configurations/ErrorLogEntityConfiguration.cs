using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Configurations
{
    public class ErrorLogEntityConfiguration : IEntityTypeConfiguration<ErrorLogEntity>
    {
        public void Configure(EntityTypeBuilder<ErrorLogEntity> builder)
        {
            builder.ToTable("tb_ErrorLogs").HasKey("Id");
        }
    }
}