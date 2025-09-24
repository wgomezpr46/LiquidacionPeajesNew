namespace LiquidacionPeajesNew.Domain.Entities
{
    public class TarifarioGaritaEntity
    {
        public int IdTarifarioGarita { get; set; }
        public long IdGarita { get; set; }
        public int EjeVehiculo { get; set; }
        public decimal ValorVenta { get; set; }
        public decimal IGV { get; set; }
        public decimal Tarifa { get; set; }

        public GaritaEntity GaritaEntity { get; set; }
    }
}