namespace LiquidacionPeajesNew.Application.DTOs.Responses
{
    public class TipoGaritaResponse
    {
        public short IdTipoGarita { get; set; }
        public string TipoGarita { get; set; }
        public short IdModoPagoGarita { get; set; }
        public string NombreModoPagoGarita { get; set; }
        public short IdEstado { get; set; }
        public string NombreEstado { get; set; }
    }
}