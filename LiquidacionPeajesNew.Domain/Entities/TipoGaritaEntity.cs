namespace LiquidacionPeajesNew.Domain.Entities
{
    public class TipoGaritaEntity
    {
        public short IdTipoGarita { get; set; }
        public string TipoGarita { get; set; }
        public short IdModoPagoGarita { get; set; }
        public short IdEstado { get; set; }

        public ModoPagoGaritaEntity ModoPagoGaritaEntity { get; set; }
        public EstadoEntity EstadoEntity { get; set; }
    }
}