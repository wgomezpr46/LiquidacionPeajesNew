using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts
{
    public class BDCNTCContext : DbContext
    {
        public BDCNTCContext(DbContextOptions<BDCNTCContext> options) : base(options) { }
    }
}