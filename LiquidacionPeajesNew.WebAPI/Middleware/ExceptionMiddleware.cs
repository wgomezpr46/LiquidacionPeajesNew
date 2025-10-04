using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Application.Services.LogService;
using LiquidacionPeajesNew.Common.Constants;
using LiquidacionPeajesNew.Common.Enums;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace LiquidacionPeajesNew.WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // ✅ Continuar con el siguiente middleware en el pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // 🛑 Registrar error local (consola, archivo, etc.)
                _logger.LogError(ex, ex.Message);

                // 🧪 Crear un scope para resolver servicios scoped (como ILogService)
                using var scope = _serviceProvider.CreateScope();
                var logService = scope.ServiceProvider.GetRequiredService<ILogService>();

                var request = context.Request;
                request.EnableBuffering(); // Permitir leer el body múltiples veces

                // 📌 Extraer parámetros de la URL (query string y route values)
                string parametersJson = "";
                try
                {
                    var queryParams = request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
                    var routeParams = context.Request.RouteValues.ToDictionary(r => r.Key, r => r.Value?.ToString() ?? "");

                    var allParams = new Dictionary<string, string>(queryParams);
                    foreach (var item in routeParams)
                    {
                        allParams[item.Key] = item.Value;
                    }

                    parametersJson = JsonConvert.SerializeObject(allParams);
                }
                catch
                {
                    parametersJson = "Error al leer parámetros de la petición.";
                }

                // 🧾 Leer encabezados del request
                string headersJson = "";
                try
                {
                    var headers = request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());
                    headersJson = JsonConvert.SerializeObject(headers);
                }
                catch
                {
                    headersJson = "Error al serializar encabezados.";
                }

                // 📄 Leer cuerpo del request
                string bodyContent = "";
                try
                {
                    if (request.ContentLength > 0 && request.Body.CanRead)
                    {
                        request.Body.Position = 0;

                        using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
                        var rawBody = await reader.ReadToEndAsync();
                        request.Body.Position = 0;

                        // Verificar si el content-type es JSON
                        if (request.ContentType != null && request.ContentType.Contains("application/json", StringComparison.OrdinalIgnoreCase))
                        {
                            try
                            {
                                // Intentar deserializar y volver a serializar (asegura que sea JSON válido y limpio)
                                var parsedJson = JsonConvert.DeserializeObject(rawBody);
                                bodyContent = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                            }
                            catch
                            {
                                // Si falla la deserialización, guardar como texto plano
                                bodyContent = rawBody;
                            }
                        }
                        else
                        {
                            // Si no es JSON, guardar como texto plano
                            bodyContent = rawBody;
                        }
                    }
                }
                catch
                {
                    bodyContent = "Error al leer el cuerpo del request.";
                }


                // 👤 Intentar obtener el usuario autenticado (si existe)
                string userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anonymous";

                // 🧱 Construir contexto del error
                var errorContext = new ErrorContextRequest
                {
                    Path = request.Path,
                    Method = request.Method,
                    Parameters = parametersJson,
                    Headers = headersJson,
                    Body = bodyContent,
                    UserId = userId
                };

                // 📝 Registrar el error en base de datos usando el servicio de logs
                await logService.LogExceptionAsync(ex, errorContext);

                // 📤 Devolver respuesta genérica al cliente
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new ApiResponse<string>(false, AppResponseMessages.GetMessage(AppResponseCode.InternalServerError));
                var responseJson = JsonConvert.SerializeObject(response);

                await context.Response.WriteAsync(responseJson);
            }
        }
    }
}