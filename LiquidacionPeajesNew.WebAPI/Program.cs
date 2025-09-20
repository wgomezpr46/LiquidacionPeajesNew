using LiquidacionPeajesNew.Application.ServiceCollection;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Contexts;
using LiquidacionPeajesNew.Infrastructure.DataAccess.EFCore.Initializers;
using LiquidacionPeajesNew.Infrastructure.ServiceCollection;
using LiquidacionPeajesNew.WebAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace LiquidacionPeajesNew.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
                        ValidIssuer = builder.Configuration["JwtSettings:Issuer"], // Emisor esperado
                        ValidAudience = builder.Configuration["JwtSettings:Audience"], // Receptor esperado
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])) // Clave secreta para validar firma
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

                // (Opcional) Agregar soporte para autenticación JWT en Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingresa el token JWT como: Bearer {tu_token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = JwtBearerDefaults.AuthenticationScheme } }, Array.Empty<string>() } });
            });

            // ----------------------------
            // 🚀 Construcción y configuración del pipeline HTTP
            // ----------------------------
            var app = builder.Build();

            // ----------------------------
            // Inicializar base de datos (crear tabla si no existe)
            // Capturamos errores para evitar caída al arrancar
            // ----------------------------
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BDALMContext>();
                await DatabaseInitializer.InitializeAsync(dbContext);
            }

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
            app.Run();                                  // Iniciar la aplicación
        }
    }
}