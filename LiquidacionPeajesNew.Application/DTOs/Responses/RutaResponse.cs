namespace LiquidacionPeajesNew.Application.DTOs.Responses
{
    public class RutaResponse
    {
        public int IdRuta { get; set; }
        public string IdOrigen { get; set; }
        public string IdDestino { get; set; }
        public string NombreOrigen { get; set; }
        public string NombreDestino { get; set; }
        public short IdEstado { get; set; }
    }
}