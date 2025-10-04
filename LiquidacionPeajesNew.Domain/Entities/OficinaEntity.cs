namespace LiquidacionPeajesNew.Domain.Entities
{
    public class OficinaEntity
    {
        public long ID_Key { get; set; }
        public string Ofi_Codigo { get; set; }
        public string Usr_Codigo { get; set; }
        public string Ofi_Nombre { get; set; }
        public string Ofi_Direccion { get; set; }
        public string Ofi_Telefono1 { get; set; }
        public string Ofi_Telefono2 { get; set; }
        public string Ofi_EMail { get; set; }
        public DateTime? Ofi_Fecha { get; set; }
        public string Ofi_Hora { get; set; }
        public string Ofi_Estado { get; set; }
        public string Suc_Codigo { get; set; }
    }
}