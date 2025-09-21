namespace LiquidacionPeajesNew.Application.DTOs.Responses
{
    public class ProveedorResponse
    {
        public int IdProveedorGarita { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public bool Impuesto { get; set; }
        public bool Detraccion { get; set; }
        public string IdTipoDocEmite { get; set; }
        public string TipoDoc { get; set; }
    }
}