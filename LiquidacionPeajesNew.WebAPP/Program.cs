
namespace LiquidacionPeajesNew.WebAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Crea el builder de la aplicación web
            var builder = WebApplication.CreateBuilder(args);

            // Construye la aplicación
            var app = builder.Build();

            // Redirige automáticamente HTTP → HTTPS
            // (Recomendado en producción)
            app.UseHttpsRedirection();

            // Habilita archivos por defecto (ej: index.html)
            // Cuando el usuario entra a "/", busca automáticamente index.html
            app.UseDefaultFiles();

            // Habilita el servicio de archivos estáticos
            // Sirve contenido desde la carpeta wwwroot
            // (index.html, assets, js, css, imágenes, etc.)
            app.UseStaticFiles();

            // IMPORTANTE para aplicaciones SPA como Vue con Vue Router en modo "history"
            // Si el usuario navega a /login, /dashboard, etc.,
            // el servidor devolverá index.html en lugar de 404.
            // Luego Vue maneja la ruta internamente.
            app.MapFallbackToFile("index.html");

            // Inicia la aplicación
            app.Run();
        }
    }
}