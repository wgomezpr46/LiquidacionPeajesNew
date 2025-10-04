using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
{
    public class GaritaRepository : IGaritaRepository
    {
        private readonly BDALMContext _context;

        public GaritaRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GaritaEntity>> GetAllAsync()
        {
            return await _context.Garitas
                .Where(x => x.IdEstado == 1)
                .Include(x => x.ZonaGaritaEntity)
                .Include(x => x.TipoGaritaEntity)
                .Include(x => x.EstadoEntity)
                .ToListAsync();
        }

        public async Task<GaritaEntity> GetByIdAsync(long id)
        {
            return await _context.Garitas
                .Include(x => x.ZonaGaritaEntity)
                .Include(x => x.TipoGaritaEntity)
                .Include(x => x.EstadoEntity)
                .FirstOrDefaultAsync(x => x.IdTipoGarita == id) ?? new GaritaEntity();
        }

        public async Task<bool> ExistsAsync(long id, string name, string ruc)
        {
            return await _context.Garitas
                .AnyAsync(x => x.NombreGarita == name && x.RucProveedor == ruc && (id == 0 || x.IdGarita != id));
        }

        public async Task AddAsync(GaritaEntity entity)
        {
            entity.IdEstado = 1;
            _context.Entry(entity).State = EntityState.Added;
            await _context.Garitas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GaritaEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Garitas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.Garitas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}