using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
{
    internal class ProveedorRepository : IProveedorRepository
    {
        private readonly BDALMContext _context;

        public ProveedorRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProveedorEntity>> GetAllAsync()
        {
            return await _context.Proveedores.Where(x => x.IdEstado == 1).Include(p => p.TipoDocumentoCompra).ToListAsync();
        }

        public async Task<ProveedorEntity> GetByIdAsync(int id)
        {
            return await _context.Proveedores.Where(p => p.IdProveedorGarita == id).FirstOrDefaultAsync() ?? new ProveedorEntity();
        }

        public async Task AddAsync(ProveedorEntity entity)
        {
            entity.IdEstado = 1;
            _context.Proveedores.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProveedorEntity entity)
        {
            _context.Proveedores.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is not null)
            {
                _context.Set<ProveedorEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}