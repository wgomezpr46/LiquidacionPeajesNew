using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioLoginEntity> GetByIdAsync(string code);
        Task<UsuarioLoginEntity> GetByNameAsync(string name);
    }
}