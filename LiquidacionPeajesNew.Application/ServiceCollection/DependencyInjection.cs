using LiquidacionPeajesNew.Application.Services.LogService;
using LiquidacionPeajesNew.Application.Services.TokenService;
using LiquidacionPeajesNew.Application.Services.UserService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LiquidacionPeajesNew.Application.ServiceCollection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra todos los perfiles de AutoMapper en este ensamblado (Application)
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Application Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddTransient<ILogService, LogService>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}