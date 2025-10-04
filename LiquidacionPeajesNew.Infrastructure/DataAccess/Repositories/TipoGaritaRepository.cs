using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
{
    public class TipoGaritaRepository : ITipoGaritaRepository
    {
        private readonly BDALMContext _context;

        public TipoGaritaRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoGaritaEntity>> GetAllAsync()
        {
            return await _context.TipoGaritas
                .Where(x => x.IdEstado == 1)
                .Include(x => x.ModoPagoGaritaEntity)
                .Include(x => x.EstadoEntity)
                .ToListAsync();
        }

        public async Task<TipoGaritaEntity> GetByIdAsync(short id)
        {
            return await _context.TipoGaritas
                .Include(x => x.ModoPagoGaritaEntity)
                .Include(x => x.EstadoEntity)
                .FirstOrDefaultAsync(x => x.IdTipoGarita == id) ?? new TipoGaritaEntity();
        }

        public async Task<bool> ExistsAsync(short id, string name)
        {
            return await _context.TipoGaritas
                .AnyAsync(x => x.TipoGarita == name && (id == 0 || x.IdTipoGarita != id));
        }

        public async Task AddAsync(TipoGaritaEntity entity)
        {
            entity.IdEstado = 1;
            _context.Entry(entity).State = EntityState.Added;
            await _context.TipoGaritas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoGaritaEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.TipoGaritas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(short id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.TipoGaritas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}