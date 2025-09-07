using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Context
{
    public class BDCNTContext : DbContext
    {
        public BDCNTContext(DbContextOptions<BDCNTContext> options) : base(options) { }
    }
}