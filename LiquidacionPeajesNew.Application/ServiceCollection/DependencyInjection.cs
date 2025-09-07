using LiquidacionPeajesNew.Application.Services.LogService;
using LiquidacionPeajesNew.Application.Services.TokenService;
using LiquidacionPeajesNew.Application.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace LiquidacionPeajesNew.Application.ServiceCollection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Application Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddTransient<ILogService, LogService>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}