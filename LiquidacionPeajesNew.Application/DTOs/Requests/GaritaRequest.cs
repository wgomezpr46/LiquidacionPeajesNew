namespace LiquidacionPeajesNew.Application.DTOs.Requests
{
    public class GaritaRequest
    {
        public string NombreGarita { get; set; }
        public string RucProveedor { get; set; }
        public byte IdZonaGarita { get; set; }
        public int UbicacionGarita { get; set; }
        public bool IdaVuelta { get; set; }
        public short IdTipoGarita { get; set; }
        public decimal MontoEjeVehLigero { get; set; }
        public decimal MontoEjeVehPesado { get; set; }
        public bool MontoPeajeDefinido { get; set; }
        public short IdEstado { get; set; }
    }
}