using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IZonaGaritaRepository
    {
        Task<IEnumerable<ZonaGaritaEntity>> GetAllAsync();
    }
}