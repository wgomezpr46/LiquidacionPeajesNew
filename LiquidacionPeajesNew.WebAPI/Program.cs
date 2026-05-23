using LiquidacionPeajesNew.Application.ServiceCollection;
using LiquidacionPeajesNew.Application.Settings;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using LiquidacionPeajesNew.Infrastructure.ServiceCollection;
using LiquidacionPeajesNew.WebAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;

namespace LiquidacionPeajesNew.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddOptions<JwtSettings>()
                .Bind(builder.Configuration.GetRequiredSection(JwtSettings.SectionName))
                .ValidateDataAnnotations()
                .Validate(settings => settings.Expires > 0, "JwtSettings:Expires debe ser mayor que cero.")
                .ValidateOnStart();

            var jwtSettings = builder.Configuration
                .GetRequiredSection(JwtSettings.SectionName)
                .Get<JwtSettings>() ?? throw new InvalidOperationException("No se pudo cargar la configuración JWT.");

            // ----------------------------
            // 🔗 Configuración de bases de datos con timeout para comandos largos (60 seg)
            // ----------------------------
            builder.Services.AddDbContext<BDALMContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BDALMConnection"), sqlOptions => sqlOptions.CommandTimeout(60)));
            builder.Services.AddDbContext<BDCNTContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BDCNTConnection"), sqlOptions => sqlOptions.CommandTimeout(60)));
            builder.Services.AddDbContext<BDCNTCContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BDCNTCConnection"), sqlOptions => sqlOptions.CommandTimeout(60)));
            builder.Services.AddDbContext<BDPASJContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BDPASJConnection"), sqlOptions => sqlOptions.CommandTimeout(60)));

            // ----------------------------
            // 🌍 Configuración de CORS (en producción limita el origen)
            // ----------------------------
            builder.Services.AddCors(o => o.AddPolicy("AllowAllCORS", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

            // ----------------------------
            // 🧩 Registrar servicios de infraestructura y aplicación (inyección de dependencias)
            // ----------------------------
            builder.Services.AddInfrastructureServices();
            builder.Services.AddApplicationServices();

            // ----------------------------
            // 🔐 Configuración global de autorización (todos los endpoints requieren autenticación)
            // ----------------------------
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            builder.Services
                .AddControllers(option =>
                {
                    option.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mantener nombres de propiedades tal como están en los DTOs (sin camelCase)
                });

            // ----------------------------
            // 🔐 Configuración de autenticación JWT
            // ----------------------------
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true, // Verificar el emisor
                        ValidateAudience = true, // Verificar el receptor
                        ValidateLifetime = true, // Verificar expiración
                        ValidateIssuerSigningKey = true, // Verificar firma
                        ValidIssuer = jwtSettings.Issuer, // Emisor esperado
                        ValidAudience = jwtSettings.Audience, // Receptor esperado
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)) // Clave secreta para validar firma
                    };
                });

            // ----------------------------
            // 📦 Configurar Swagger (documentación de API) con soporte JWT
            // ----------------------------
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LiquidacionPeajesNew.WebAPI",
                    Version = "v1"
                });

                // Definición de seguridad JWT
                var securitySchemeName = JwtBearerDefaults.AuthenticationScheme;

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Ingresa el token JWT en el formato: Bearer {tu_token}",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT"
                };

                c.AddSecurityDefinition(securitySchemeName, securityScheme);

                // Requerimiento global para todos los endpoints
                c.AddSecurityRequirement(_ => new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecuritySchemeReference(securitySchemeName, null, null),
                        new List<string>()
                    }
                });
            });

            // ----------------------------
            // 🚀 Construcción y configuración del pipeline HTTP
            // ----------------------------
            var app = builder.Build();

            // ----------------------------
            // Habilitar Swagger solo en desarrollo
            // ----------------------------
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();                  // Forzar HTTPS
            app.UseRouting();                           // Habilitar enrutamiento
            app.UseCors("AllowAllCORS");                // Aplicar política CORS (ideal antes de auth)
            app.UseMiddleware<ExceptionMiddleware>();   // Middleware para manejo y logging de excepciones
            app.UseAuthentication();                    // Habilitar autenticación JWT
            app.UseAuthorization();                     // Habilitar autorización (roles/políticas)
            app.MapControllers();                       // Mapear controladores a endpoints
            await app.RunAsync();                                  // Iniciar la aplicación
        }
    }
}