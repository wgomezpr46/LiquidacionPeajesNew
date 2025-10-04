using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
{
    public class TarifarioGaritaRepository : ITarifarioGaritaRepository
    {
        private readonly BDALMContext _context;

        public TarifarioGaritaRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TarifarioGaritaEntity>> GetAllAsync()
        {
            return await _context.TarifarioGaritas
                .Include(x => x.GaritaEntity)
                .ToListAsync();
        }

        public async Task<TarifarioGaritaEntity> GetByIdAsync(int id)
        {
            return await _context.TarifarioGaritas
                .Include(x => x.GaritaEntity)
                .FirstOrDefaultAsync(x => x.IdTarifarioGarita == id) ?? new TarifarioGaritaEntity();
        }

        public async Task<bool> ExistsAsync(int id, long idGarita, int ejeVehiculo)
        {
            return await _context.TarifarioGaritas
                .AnyAsync(x => x.IdGarita == idGarita && x.EjeVehiculo == ejeVehiculo && (id == 0 || x.IdTarifarioGarita != id));
        }

        public async Task AddAsync(TarifarioGaritaEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.TarifarioGaritas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TarifarioGaritaEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.TarifarioGaritas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.TarifarioGaritas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}