using LiquidacionPeajesNew.Application.Services.EstadoService;
using LiquidacionPeajesNew.Application.Services.LogService;
using LiquidacionPeajesNew.Application.Services.OficinaService;
using LiquidacionPeajesNew.Application.Services.ProveedorService;
using LiquidacionPeajesNew.Application.Services.RutaService;
using LiquidacionPeajesNew.Application.Services.TipoDocumentoCompraService;
using LiquidacionPeajesNew.Application.Services.TokenService;
using LiquidacionPeajesNew.Application.Services.UserService;
using LiquidacionPeajesNew.Application.Services.ZonaGaritaService;
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
            services.AddTransient<ILogService, LogService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRutaService, RutaService>();
            services.AddScoped<IOficinaService, OficinaService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IZonaGaritaService, ZonaGaritaService>();
            services.AddScoped<ITipoDocumentoCompraService, TipoDocumentoCompraService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}