using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LiquidacionPeajesNew.Infrastructure.ServiceCollection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Domain Interfaces
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IRutaRepository, RutaRepository>();
            services.AddScoped<IOficinaRepository, OficinaRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IZonaGaritaRepository, ZonaGaritaRepository>();
            services.AddScoped<ITipoDocumentoCompraRepository, TipoDocumentoCompraRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IModoPagoGaritaRepository, ModoPagoGaritaRepository>();
            services.AddScoped<ITipoGaritaRepository, TipoGaritaRepository>();
            services.AddScoped<IGaritaRepository, GaritaRepository>();
            services.AddScoped<ITarifarioGaritaRepository, TarifarioGaritaRepository>();

            return services;
        }
    }
}