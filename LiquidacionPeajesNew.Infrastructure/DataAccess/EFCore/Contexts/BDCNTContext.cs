using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts
{
    public class BDCNTContext : DbContext
    {
        public BDCNTContext(DbContextOptions<BDCNTContext> options) : base(options) { }
    }
}