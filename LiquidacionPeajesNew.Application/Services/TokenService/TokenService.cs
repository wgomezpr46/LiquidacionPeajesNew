using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Enums;
using LiquidacionPeajesNew.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LiquidacionPeajesNew.Application.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public TokenService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<TokenResponse>> Login(string name, string password)
        {
            var user = await _userRepository.GetByNameAsync(name);

            if (user.Contrasena == password)
            {
                var userRequest = new UserRequest
                {
                    Usr_Codigo = user.IdUsuario,
                    Usr_Nombre = user.Usuario,
                    Usr_Estado = user.Estado
                };

                var tokenResponse = GenerateToken(userRequest);
                if (tokenResponse.Status)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadJwtToken(tokenResponse.Value);

                    var response = new TokenResponse
                    {
                        IsValid = true,
                        IsRenewed = false,
                        Message = AppResponseMessages.GetMessage(AppResponseCode.TokenGeneratedSuccessfully),
                        TokenType = JwtBearerDefaults.AuthenticationScheme,
                        AccessToken = tokenResponse.Value,
                        Claims = jwt.Claims.ToDictionary(c => c.Type, c => c.Value)
                    };

                    return new ApiResponse<TokenResponse>(true, response, AppResponseCode.AuthenticationSuccessful);
                }
                else
                {
                    return new ApiResponse<TokenResponse>(false, null, AppResponseCode.UnknownError);
                }
            }
            else
            {
                return new ApiResponse<TokenResponse>(false, null, AppResponseCode.IncorrectPassword);

            }
        }

        public ApiResponse<string> GenerateToken(UserRequest request)
        {
            if (request.Usr_Codigo > 0)
            {
                var usuario = _userRepository.GetByIdAsync(request.Usr_Codigo);
                request.Usr_Nombre = usuario.Result.Usuario;
                request.Usr_Estado = usuario.Result.Estado;
            }
            // 🧾 Claims del token (información que viaja dentro del token)
            Claim[] claims = new Claim[]
            {
                // ID único del token (buenas prácticas para evitar ataques de repetición)
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                // Identificador del sujeto (en este caso, el código del usuario)
                new(JwtRegisteredClaimNames.Sub, Convert.ToString(request.Usr_Codigo)),

                // Claims personalizados del usuario
                new("Usr_Codigo", Convert.ToString(request.Usr_Codigo)),
                new("Usr_Nombre", Convert.ToString(request.Usr_Nombre)),
                new("Usr_Estado", Convert.ToString(request.Usr_Estado)),
            };

            // 🔐 Obtener la clave secreta desde la configuración
            var secretKey = _configuration.GetValue<string>("JwtSettings:Key");

            // Validar que la clave tenga al menos 16 caracteres (requisito para HmacSha256)
            if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 16)
            {
                throw new InvalidOperationException(AppResponseMessages.GetMessage(AppResponseCode.TokenKeyTooShort));
            }

            // Convertir la clave en bytes y generar la clave de seguridad simétrica
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // 📝 Crear las credenciales de firma usando el algoritmo HMAC SHA-256
            var signing = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 📦 Crear el token JWT
            JwtSecurityToken jwt = new(
                issuer: _configuration.GetValue<string>("JwtSettings:Issuer"),                                              // Emisor del token
                audience: _configuration.GetValue<string>("JwtSettings:Audience"),                                          // Receptor esperado del token
                claims: claims,                                                                                             // Información dentro del token
                expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration.GetValue<string>("JwtSettings:expires"))),   // Tiempo de expiración (1 hora)
                signingCredentials: signing                                                                                 // Firma del token
            );

            // 🧾 Serializar el token a string y retornarlo
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new ApiResponse<string>(true, token, AppResponseCode.OperationCompletedSuccessfully);
        }

        public ApiResponse<TokenResponse> ValidateToken(TokenRequest request)
        {
            var handler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtSettings:Key"));
            TokenResponse tokenResponse = new();

            if (request == null || string.IsNullOrEmpty(request.AccessToken) || request.UserRequest == null)
            {
                return new ApiResponse<TokenResponse>(false, null, AppResponseCode.MissingTokenAndUserData);
            }

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true, // ✅ Validamos la expiración
                ValidIssuer = _configuration.GetValue<string>("JwtSettings:Issuer"),   // Emisor del token
                ValidAudience = _configuration.GetValue<string>("JwtSettings:Audience"), // Receptor esperado del token
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                ClockSkew = TimeSpan.Zero // ⏱️ Sin tolerancia de tiempo
            };

            try
            {
                var principal = handler.ValidateToken(request.AccessToken, tokenValidationParameters, out SecurityToken validatedToken);

                if (validatedToken is not JwtSecurityToken jwt || jwt.Header.Alg != SecurityAlgorithms.HmacSha256)
                {
                    throw new SecurityTokenException(AppResponseMessages.GetMessage(AppResponseCode.TokenInvalid));
                }

                // ✅ Token válido
                tokenResponse = new TokenResponse
                {
                    IsValid = true,
                    IsRenewed = false,
                    Message = AppResponseMessages.GetMessage(AppResponseCode.TokenNotExpiredYet),
                    TokenType = JwtBearerDefaults.AuthenticationScheme,
                    AccessToken = request.AccessToken,
                    Claims = principal.Claims.ToDictionary(c => c.Type, c => c.Value)
                };
            }
            catch (SecurityTokenExpiredException)
            {
                // 📌 Token expirado: validamos si renovamos
                var jwt = handler.ReadJwtToken(request.AccessToken);
                if (jwt.ValidTo > DateTime.UtcNow.AddMinutes(-10)) // expiró hace menos de 10 minutos
                {
                    var response = GenerateToken(request.UserRequest);
                    if (response.Status)
                    {
                        var NewJwt = handler.ReadJwtToken(response.Value);

                        tokenResponse = new TokenResponse
                        {
                            IsValid = true,
                            IsRenewed = true,
                            Message = AppResponseMessages.GetMessage(AppResponseCode.TokenRenewed),
                            TokenType = JwtBearerDefaults.AuthenticationScheme,
                            AccessToken = response.Value,
                            Claims = NewJwt.Claims.ToDictionary(c => c.Type, c => c.Value)
                        };
                    }
                }
                else
                {
                    // ⛔ Token muy antiguo
                    tokenResponse = new TokenResponse
                    {
                        IsValid = false,
                        Message = AppResponseMessages.GetMessage(AppResponseCode.TokenCannotBeRenewed),
                    };
                }
            }
            catch
            {
                // ⛔ Token inválido o corrupto
                tokenResponse = new TokenResponse
                {
                    IsValid = false,
                    Message = AppResponseMessages.GetMessage(AppResponseCode.TokenInvalid),
                };
            }

            return new ApiResponse<TokenResponse>(true, tokenResponse, AppResponseCode.OperationCompletedSuccessfully);
        }
    }
}