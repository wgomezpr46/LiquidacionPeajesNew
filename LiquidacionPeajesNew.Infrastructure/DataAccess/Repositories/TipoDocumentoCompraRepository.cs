using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories
{
    internal class TipoDocumentoCompraRepository : ITipoDocumentoCompraRepository
    {
        private readonly BDALMContext _context;

        public TipoDocumentoCompraRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoDocumentoCompraEntity>> GetAllAsync()
        {
            return await _context.TipoDocumentoCompras.ToListAsync();
        }
    }
}