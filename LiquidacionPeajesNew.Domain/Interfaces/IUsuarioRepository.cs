using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioLoginEntity> GetByIdAsync(string codigo);
        Task<UsuarioLoginEntity> GetByNameAsync(string nombre);
    }
}