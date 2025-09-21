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

        public async Task<ZonaGaritaEntity> GetByIdAsync(byte id)
        {
            return await _context.ZonaGaritas.FirstOrDefaultAsync(x => x.IdZonaGarita == id) ?? new ZonaGaritaEntity();
        }

        public async Task AddAsync(ZonaGaritaEntity entity)
        {
            entity.IdEstado = 1;
            await _context.Set<ZonaGaritaEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ZonaGaritaEntity entity)
        {
            _context.Set<ZonaGaritaEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(byte id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is not null)
            {
                _context.Set<ZonaGaritaEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}