using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts
{
    public class BDPASJContext : DbContext
    {
        public BDPASJContext(DbContextOptions<BDPASJContext> options) : base(options) { }
    }
}