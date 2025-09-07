using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly BDALMContext _context;

        public UserRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity> GetByIdAsync(short id)
        {
            return await _context.Users.Where(x => x.IdUsuario == id).FirstOrDefaultAsync() ?? new UserEntity();
        }

        public async Task<UserEntity> GetByNameAsync(string name)
        {
            return await _context.Users.Where(x => x.Usuario == name).FirstOrDefaultAsync() ?? new UserEntity();
        }
    }
}