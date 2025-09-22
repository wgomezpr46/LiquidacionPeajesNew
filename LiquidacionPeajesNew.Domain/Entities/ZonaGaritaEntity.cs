namespace LiquidacionPeajesNew.Domain.Entities
{
    public class ZonaGaritaEntity
    {
        public short IdZonaGarita { get; set; }
        public string ZonaGarita { get; set; }
        public short IdEstado { get; set; }

        public EstadoEntity EstadoEntity { get; set; }
    }
}