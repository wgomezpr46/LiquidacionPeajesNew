namespace LiquidacionPeajesNew.Application.DTOs.Requests
{
    public class UsuarioLoginRequest
    {
        public string Usr_Codigo { get; set; }
        public string Usr_Nombre { get; set; }
        public string Usr_Password { get; set; }
        public string Usr_Nivel { get; set; }
        public string Usr_Estado { get; set; }
        public string CODI_SUCURSAL { get; set; }
        public string Ben_Codigo { get; set; }
        public int TbPerfil_id { get; set; }
        public string Ccosto { get; set; }
        public string CodAux2 { get; set; }
        public string CodAux3 { get; set; }
        public string CodAux4 { get; set; }
        public string Usr_CodEmp { get; set; }
        public int Formato { get; set; }
        public string Ofi_Codigo { get; set; }
    }
}