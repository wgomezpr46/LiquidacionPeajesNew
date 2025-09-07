namespace LiquidacionPeajesNew.Domain.Entities
{
    public class UserEntity
    {
        public short IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Nivel { get; set; }
        public string Ofi_Codigo { get; set; }
        public string Ben_Codigo { get; set; }
        public string Usr_Terminal { get; set; }
        public short IdEmpresa { get; set; }
        public short IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
    }
}