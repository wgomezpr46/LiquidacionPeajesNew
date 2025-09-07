using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Context
{
    public class BDCNTCContest : DbContext
    {
        public BDCNTCContest(DbContextOptions<BDCNTCContest> options) : base(options) { }
    }
}