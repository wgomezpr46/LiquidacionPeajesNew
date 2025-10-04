namespace LiquidacionPeajesNew.Application.DTOs.Responses
{
    public class GaritaResponse
    {
        public long IdGarita { get; set; }
        public string NombreGarita { get; set; }
        public string RucProveedor { get; set; }
        public short IdZonaGarita { get; set; }
        public string NombreZonaGarita { get; set; }
        public int UbicacionGarita { get; set; }
        public bool IdaVuelta { get; set; }
        public short IdTipoGarita { get; set; }
        public string NombreTipoGarita { get; set; }
        public decimal MontoEjeVehLigero { get; set; }
        public decimal MontoEjeVehPesado { get; set; }
        public bool MontoPeajeDefinido { get; set; }
        public short IdEstado { get; set; }
        public string NombreEstado { get; set; }
    }
}