namespace LiquidacionPeajesNew.Application.DTOs.Responses
{
    public class TokenResponse
    {
        public bool IsValid { get; set; }
        public bool IsRenewed { get; set; }
        public string Message { get; set; }
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public Dictionary<string, string> Claims { get; set; } = new();
    }
}