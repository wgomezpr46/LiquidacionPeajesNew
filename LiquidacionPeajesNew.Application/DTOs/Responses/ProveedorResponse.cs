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
        public string NombreTipoDoc { get; set; }
        public short IdEstado { get; set; }
        public string NombreEstado { get; set; }
    }
}