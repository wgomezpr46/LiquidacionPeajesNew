using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LiquidacionPeajesNew.Infrastructure.ServiceCollection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Domain Interfaces
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}