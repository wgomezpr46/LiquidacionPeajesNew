using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
{
    public class ZonaGaritaRepository : IZonaGaritaRepository
    {
        private readonly BDALMContext _context;

        public ZonaGaritaRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ZonaGaritaEntity>> GetAllAsync()
        {
            return await _context.ZonaGaritas.Where(x => x.IdEstado == 1).ToListAsync();
        }
    }
}