namespace LiquidacionPeajesNew.Application.DTOs.Requests
{
    public class ErrorContextRequest
    {
        public string Path { get; set; }
        public string Method { get; set; }
        public string Parameters { get; set; }
        public string Headers { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
    }
}