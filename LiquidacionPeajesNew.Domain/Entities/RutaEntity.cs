namespace LiquidacionPeajesNew.Domain.Entities
{
    public class RutaEntity
    {
        public int IdRuta { get; set; }
        public string IdOrigen { get; set; }
        public string IdDestino { get; set; }
        public string UbigeoOrigen { get; set; }
        public string UbigeoDestino { get; set; }
        public short IdEstado { get; set; }
    }
}