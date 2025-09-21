using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
{
    public class ModoPagoGaritaRepository : IModoPagoGaritaRepository
    {
        private readonly BDALMContext _context;

        public ModoPagoGaritaRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ModoPagoGaritaEntity>> GetAllAsync()
        {
            return await _context.ModoPagoGaritas
                .Where(x => x.IdEstado == 1)
                .Include(x => x.EstadoEntity)
                .ToListAsync();
        }

        public async Task<ModoPagoGaritaEntity> GetByIdAsync(short id)
        {
            return await _context.ModoPagoGaritas
                .Include(x => x.EstadoEntity)
                .FirstOrDefaultAsync(x => x.IdModoPagoGarita == id) ?? new ModoPagoGaritaEntity();
        }

        public async Task<ModoPagoGaritaEntity> GetByNameAsync(short id, string name)
        {
            if (id > 0)
            {
                return await _context.ModoPagoGaritas
                    .Include(x => x.EstadoEntity)
                    .FirstOrDefaultAsync(x => x.IdModoPagoGarita != id && x.ModoPagoGarita == name) ?? new ModoPagoGaritaEntity();
            }
            else
            {
                return await _context.ModoPagoGaritas
                    .Include(x => x.EstadoEntity)
                    .FirstOrDefaultAsync(x => x.ModoPagoGarita == name) ?? new ModoPagoGaritaEntity();
            }
        }

        public async Task AddAsync(ModoPagoGaritaEntity entity)
        {
            entity.IdEstado = 1;
            _context.Entry(entity).State = EntityState.Added;
            await _context.ModoPagoGaritas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ModoPagoGaritaEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.ModoPagoGaritas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(short id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.ModoPagoGaritas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}