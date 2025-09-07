namespace LiquidacionPeajesNew.Application.DTOs.Requests
{
    public class TokenRequest
    {
        public UserRequest UserRequest { get; set; }
        public string AccessToken { get; set; }
    }
}