namespace LiquidacionPeajesNew.Domain.Entities
{
    public class ModoPagoGaritaEntity
    {
        public short IdModoPagoGarita { get; set; }
        public string ModoPagoGarita { get; set; }
        public short IdEstado { get; set; }

        public EstadoEntity EstadoEntity { get; set; }
    }
}