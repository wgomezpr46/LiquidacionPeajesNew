using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Repositories
{
    public class RutaRepository : IRutaRepository
    {
        private readonly BDCNTContext _context;

        public RutaRepository(BDCNTContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RutaEntity>> GetAllAsync()
        {
            return await _context.Set<RutaEntity>().ToListAsync();
        }

        public async Task<RutaEntity> GetByIdAsync(int id)
        {
            return await _context.Set<RutaEntity>().FindAsync(id) ?? new RutaEntity();
        }

        public async Task AddAsync(RutaEntity ruta)
        {
            await _context.Set<RutaEntity>().AddAsync(ruta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RutaEntity ruta)
        {
            _context.Set<RutaEntity>().Update(ruta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is not null)
            {
                _context.Set<RutaEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}