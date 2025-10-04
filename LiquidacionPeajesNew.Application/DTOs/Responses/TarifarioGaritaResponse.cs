namespace LiquidacionPeajesNew.Application.DTOs.Responses
{
    public class TarifarioGaritaResponse
    {
        public int IdTarifarioGarita { get; set; }
        public long IdGarita { get; set; }
        public int EjeVehiculo { get; set; }
        public decimal ValorVenta { get; set; }
        public decimal IGV { get; set; }
        public decimal Tarifa { get; set; }
        public string NombreGarita { get; set; }
    }
}