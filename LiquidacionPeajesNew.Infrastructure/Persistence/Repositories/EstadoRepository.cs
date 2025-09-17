using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly BDALMContext _context;

        public EstadoRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<ICollection<EstadoEntity>> GetAllAsync()
        {
            return await _context.Estados.ToListAsync();
        }
    }
}