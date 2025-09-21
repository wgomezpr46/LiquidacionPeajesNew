namespace LiquidacionPeajesNew.Application.DTOs.Requests
{
    public class ProveedorRequest
    {
        public int IdProveedorGarita { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public bool Impuesto { get; set; }
        public bool Detraccion { get; set; }
        public string IdTipoDocEmite { get; set; }
        public short IdEstado { get; set; }
    }
}