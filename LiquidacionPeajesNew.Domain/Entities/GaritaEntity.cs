namespace LiquidacionPeajesNew.Domain.Entities
{
    public class GaritaEntity
    {
        public long IdGarita { get; set; }
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

        public ZonaGaritaEntity ZonaGaritaEntity { get; set; }
        public TipoGaritaEntity TipoGaritaEntity { get; set; }
        public EstadoEntity EstadoEntity { get; set; }
    }
}