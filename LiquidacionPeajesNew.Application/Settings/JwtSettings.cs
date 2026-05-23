using System.ComponentModel.DataAnnotations;

namespace LiquidacionPeajesNew.Application.Settings
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";

        [Required]
        [MinLength(16)]
        public string Key { get; set; } = string.Empty;

        [Required]
        public string Issuer { get; set; } = string.Empty;

        [Required]
        public string Audience { get; set; } = string.Empty;

        [Range(1, 168)]
        public double Expires { get; set; }
    }
}