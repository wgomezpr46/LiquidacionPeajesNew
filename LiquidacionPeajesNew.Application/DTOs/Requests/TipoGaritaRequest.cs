namespace LiquidacionPeajesNew.Application.DTOs.Requests
{
    public class TipoGaritaRequest
    {
        public short IdTipoGarita { get; set; }
        public string TipoGarita { get; set; }
        public short IdModoPagoGarita { get; set; }
        public short IdEstado { get; set; }
    }
}