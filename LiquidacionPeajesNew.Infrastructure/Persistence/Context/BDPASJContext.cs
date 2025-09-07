using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Context
{
    public class BDPASJContext : DbContext
    {
        public BDPASJContext(DbContextOptions<BDPASJContext> options) : base(options) { }
    }
}