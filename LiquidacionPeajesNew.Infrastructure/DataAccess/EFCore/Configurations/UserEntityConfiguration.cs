using LiquidacionPeajesNew.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("tb_Usuario").HasKey("IdUsuario");
        }
    }
}