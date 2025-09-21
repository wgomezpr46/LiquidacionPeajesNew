using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UsuarioLoginEntity> GetByIdAsync(string code);
        Task<UsuarioLoginEntity> GetByNameAsync(string name);
    }
}