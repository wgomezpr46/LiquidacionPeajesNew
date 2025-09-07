using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Context
{
    public class BDCNTCContext : DbContext
    {
        public BDCNTCContext(DbContextOptions<BDCNTCContext> options) : base(options) { }
    }
}