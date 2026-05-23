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
            return await _context.ZonaGaritas
                .Where(x => x.IdEstado == 1)
                .Include(x => x.EstadoEntity)
                .ToListAsync();
        }

        public async Task<ZonaGaritaEntity> GetByIdAsync(byte id)
        {
            return await _context.ZonaGaritas
                .Include(x => x.EstadoEntity)
                .FirstOrDefaultAsync(x => x.IdZonaGarita == id) ?? new ZonaGaritaEntity();
        }

        public async Task<bool> ExistsAsync(byte id, string name)
        {
            return await _context.ZonaGaritas
                .AnyAsync(x => x.ZonaGarita == name && (id == 0 || x.IdZonaGarita != id));
        }

        public async Task AddAsync(ZonaGaritaEntity entity)
        {
            entity.IdEstado = 1;
            _context.Entry(entity).State = EntityState.Added;
            await _context.ZonaGaritas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ZonaGaritaEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.ZonaGaritas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(byte id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.ZonaGaritas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}