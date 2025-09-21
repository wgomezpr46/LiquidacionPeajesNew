using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
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

        public async Task AddAsync(RutaEntity entity)
        {
            await _context.Set<RutaEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RutaEntity entity)
        {
            _context.Set<RutaEntity>().Update(entity);
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