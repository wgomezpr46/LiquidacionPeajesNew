using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
{
    public class RutaRepository : IRutaRepository
    {
        private readonly BDALMContext _context;

        public RutaRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RutaEntity>> GetAllAsync()
        {
            return await _context.Rutas
                .Where(x => x.IdEstado == 1)
                .Include(x => x.EstadoEntity)
                .ToListAsync();
        }

        public async Task<RutaEntity> GetByIdAsync(int id)
        {
            return await _context.Rutas
                .Include(x => x.EstadoEntity)
                .FirstOrDefaultAsync(x => x.IdRuta == id) ?? new RutaEntity();
        }

        public async Task<bool> ExistsAsync(int id, string IdOrigen, string IdDestino)
        {
            return await _context.Rutas
                .AnyAsync(x => x.IdOrigen == IdOrigen && x.IdDestino == IdDestino && (id == 0 || x.IdRuta != id));
        }

        public async Task AddAsync(RutaEntity entity)
        {
            entity.IdEstado = 1;
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
            if (entity != null)
            {
                _context.Set<RutaEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}