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
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception for request {Method} {Path}", context.Request.Method, context.Request.Path);

                var errorContext = await BuildErrorContextAsync(context);
                await TryPersistLogAsync(ex, errorContext);
                await TryWriteErrorResponseAsync(context);
            }
        }

        private async Task<ErrorContextRequest> BuildErrorContextAsync(HttpContext context)
        {
            var request = context.Request;
            request.EnableBuffering();

            var parametersJson = TrySerializeRequestParameters(context);
            var headersJson = TrySerializeHeaders(request);
            var bodyContent = await TryReadBodyAsync(request);
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anonymous";

            return new ErrorContextRequest
            {
                Path = request.Path,
                Method = request.Method,
                Parameters = parametersJson,
                Headers = headersJson,
                Body = bodyContent,
                UserId = userId
            };
        }

        private async Task TryPersistLogAsync(Exception ex, ErrorContextRequest errorContext)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var logService = scope.ServiceProvider.GetRequiredService<ILogService>();
                await logService.LogExceptionAsync(ex, errorContext);
            }
            catch (Exception logEx)
            {
                _logger.LogError(logEx, "Failed to persist exception details. Original error: {OriginalMessage}", ex.Message);
            }
        }

        private async Task TryWriteErrorResponseAsync(HttpContext context)
        {
            if (context.Response.HasStarted)
            {
                _logger.LogWarning("The response has already started, the exception middleware cannot write the error response.");
                return;
            }

            try
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new ApiResponse<string>(false, AppResponseMessages.GetMessage(AppResponseCode.InternalServerError));
                var responseJson = JsonConvert.SerializeObject(response);

                await context.Response.WriteAsync(responseJson);
            }
            catch (Exception responseEx)
            {
                _logger.LogError(responseEx, "Failed to write the error response.");
            }
        }

        private static string TrySerializeRequestParameters(HttpContext context)
        {
            try
            {
                var queryParams = context.Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
                var routeParams = context.Request.RouteValues.ToDictionary(r => r.Key, r => r.Value?.ToString() ?? string.Empty);

                var allParams = new Dictionary<string, string>(queryParams);
                foreach (var item in routeParams)
                {
                    allParams[item.Key] = item.Value;
                }

                return JsonConvert.SerializeObject(allParams);
            }
            catch
            {
                return "Error al leer parámetros de la petición.";
            }
        }

        private static string TrySerializeHeaders(HttpRequest request)
        {
            try
            {
                var headers = request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());
                return JsonConvert.SerializeObject(headers);
            }
            catch
            {
                return "Error al serializar encabezados.";
            }
        }

        private static async Task<string> TryReadBodyAsync(HttpRequest request)
        {
            try
            {
                if (request.ContentLength is null or <= 0 || !request.Body.CanRead)
                {
                    return string.Empty;
                }

                if (request.Body.CanSeek)
                {
                    request.Body.Position = 0;
                }

                using var reader = new StreamReader(request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
                var rawBody = await reader.ReadToEndAsync();

                if (request.Body.CanSeek)
                {
                    request.Body.Position = 0;
                }

                if (string.IsNullOrWhiteSpace(rawBody))
                {
                    return string.Empty;
                }

                if (request.ContentType != null && request.ContentType.Contains("application/json", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        var parsedJson = JsonConvert.DeserializeObject(rawBody);
                        return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                    }
                    catch
                    {
                        return rawBody;
                    }
                }

                return rawBody;
            }
            catch
            {
                return "Error al leer el cuerpo del request.";
            }
        }
    }
}