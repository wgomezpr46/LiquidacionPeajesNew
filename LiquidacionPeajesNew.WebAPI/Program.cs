using LiquidacionPeajesNew.Application.ServiceCollection;
using LiquidacionPeajesNew.Infrastructure.Persistence.Context;
using LiquidacionPeajesNew.Infrastructure.ServiceCollection;
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
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ----------------------------
            // 🔗 Configuración de bases de datos
            // ----------------------------
            builder.Services.AddDbContext<BDALMContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BDALMConnection")));
            builder.Services.AddDbContext<BDCNTContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BDCNTConnection")));
            builder.Services.AddDbContext<BDCNTCContest>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BDCNTCConnection")));
            builder.Services.AddDbContext<BDPASJContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BDPASJConnection")));

            // ----------------------------
            // 🌍 Configurar CORS (permitir acceso desde cualquier origen)
            // ----------------------------
            builder.Services.AddCors(o => o.AddPolicy("AllowAllCORS", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // ----------------------------
            // 🧩 Registrar servicios de infraestructura y aplicación (inyección de dependencias)
            // ----------------------------
            builder.Services.AddInfrastructureServices();
            builder.Services.AddApplicationServices();

            // ----------------------------
            // 🔐 Configuración global de autorización (todos los endpoints requieren autenticación)
            // ----------------------------
            builder.Services.AddControllers(option =>
            {
                var police = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                option.Filters.Add(new AuthorizeFilter(police));
            })
            .AddJsonOptions(options =>
            {
                // Mantener nombres de propiedades tal como están en los DTOs (sin camelCase)
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            // ----------------------------
            // 🔐 Configuración de autenticación JWT
            // ----------------------------
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])) // Clave secreta para validar firma
                    };
                });

            // ----------------------------
            // 📦 Configurar Swagger (documentación de API)
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

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // ----------------------------
            // 🚀 Construcción y configuración del pipeline HTTP
            // ----------------------------
            var app = builder.Build();

            // Usar Swagger solo en desarrollo
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();         // Forzar HTTPS
            app.UseRouting();                  // Habilitar enrutamiento
            app.UseAuthentication();           // Habilitar autenticación JWT
            app.UseAuthorization();            // Habilitar autorización por roles/políticas
            app.UseCors("AllowAllCORS");       // Aplicar política CORS

            app.MapControllers();              // Mapear controladores a endpoints
            app.Run();                         // Iniciar la aplicación
        }
    }
}
