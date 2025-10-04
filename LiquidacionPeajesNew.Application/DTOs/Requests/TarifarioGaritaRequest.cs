namespace LiquidacionPeajesNew.Application.DTOs.Requests
{
    public class TarifarioGaritaRequest
    {
        public long IdGarita { get; set; }
        public int EjeVehiculo { get; set; }
        public decimal ValorVenta { get; set; }
        public decimal IGV { get; set; }
        public decimal Tarifa { get; set; }
    }
}