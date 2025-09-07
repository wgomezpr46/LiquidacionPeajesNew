namespace LiquidacionPeajesNew.Domain.Entities
{
    public class ErrorLogEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public string Message { get; set; } = null!;
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string InnerException { get; set; }

        public string RequestPath { get; set; }
        public string RequestMethod { get; set; }
        public string RequestParameters { get; set; }   // Guardados como JSON
        public string RequestHeaders { get; set; }      // Guardados como JSON
        public string RequestBody { get; set; }         // Guardado como texto plano o JSON

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}