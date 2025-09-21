using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LiquidacionPeajesNew.Application.Services.LogService
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogService(ILogRepository logRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logRepository = logRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogExceptionAsync(Exception ex, ErrorContextRequest context)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            var errorLog = new ErrorLogEntity
            {
                UserId = context.UserId,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Source = ex.Source,
                InnerException = ex.InnerException?.Message,
                RequestPath = context.Path,
                RequestMethod = context.Method,
                RequestParameters = context.Parameters,
                RequestHeaders = context.Headers,
                RequestBody = context.Body,
                CreatedAt = DateTime.UtcNow
            };

            await _logRepository.SaveAsync(errorLog);
        }
    }
}