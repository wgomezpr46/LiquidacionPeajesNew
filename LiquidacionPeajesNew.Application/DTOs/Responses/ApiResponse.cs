using LiquidacionPeajesNew.Domain.Enums;

namespace LiquidacionPeajesNew.Application.DTOs.Responses
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public T Value { get; set; }
        public string Message { get; set; }
        public int? ErrorCode { get; set; }
        public object Metadata { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool status)
        {
            Status = status;
        }

        public ApiResponse(bool status, T value)
        {
            Status = status;
            Value = value;
        }

        public ApiResponse(bool status, T value, AppResponseCode messageCode, string language = LanguageCodes.Inglés)
        {
            Status = status;
            Value = value;
            Message = AppResponseMessages.GetMessage(messageCode, language);
            ErrorCode = (!status) ? (int)messageCode : null;
        }

        public ApiResponse(bool status, T value, AppResponseCode messageCode, object metadata, string language = LanguageCodes.Inglés)
        {
            Status = status;
            Value = value;
            Message = AppResponseMessages.GetMessage(messageCode, language);
            ErrorCode = (!status) ? (int)messageCode : null;
            Metadata = metadata;
        }
    }
}