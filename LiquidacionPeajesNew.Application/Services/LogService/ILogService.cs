using LiquidacionPeajesNew.Application.DTOs.Requests;

namespace LiquidacionPeajesNew.Application.Services.LogService
{
    public interface ILogService
    {
        Task LogExceptionAsync(Exception ex, ErrorContextRequest context);
    }
}