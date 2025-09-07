using LiquidacionPeajesNew.Common.Enums;

namespace LiquidacionPeajesNew.Common.Constants
{
    public static class AppResponseMessages
    {
        private static readonly Dictionary<int, Dictionary<string, string>> Messages = new()
        {
            #region User-related errors (1000-1999)

            [(int)AppResponseCode.UserNotFound] = new()
            {
                ["en"] = "User not found.",
                ["es"] = "Usuario no encontrado."
            },
            [(int)AppResponseCode.InvalidInput] = new()
            {
                ["en"] = "Invalid input.",
                ["es"] = "Entrada inválida."
            },
            [(int)AppResponseCode.InvalidCredentials] = new()
            {
                ["en"] = "Invalid credentials.",
                ["es"] = "Credenciales inválidas."
            },
            [(int)AppResponseCode.AccountLocked] = new()
            {
                ["en"] = "Account is locked.",
                ["es"] = "La cuenta está bloqueada."
            },
            [(int)AppResponseCode.InvalidToken] = new()
            {
                ["en"] = "Invalid token.",
                ["es"] = "Token inválido."
            },
            [(int)AppResponseCode.UnauthorizedAction] = new()
            {
                ["en"] = "Unauthorized action.",
                ["es"] = "Acción no autorizada."
            },
            [(int)AppResponseCode.UserAlreadyExists] = new()
            {
                ["en"] = "User already exists.",
                ["es"] = "El usuario ya existe."
            },
            [(int)AppResponseCode.EmailNotVerified] = new()
            {
                ["en"] = "Email not verified.",
                ["es"] = "Email no verificado."
            },
            [(int)AppResponseCode.UserSuspended] = new()
            {
                ["en"] = "User suspended.",
                ["es"] = "Usuario suspendido."
            },
            [(int)AppResponseCode.InvalidPhoneNumber] = new()
            {
                ["en"] = "Invalid phone number.",
                ["es"] = "Número de teléfono inválido."
            },
            [(int)AppResponseCode.UserBanned] = new()
            {
                ["en"] = "User banned.",
                ["es"] = "Usuario bloqueado."
            },
            [(int)AppResponseCode.IncorrectPassword] = new()
            {
                ["en"] = "Incorrect password.",
                ["es"] = "Contraseña incorrecta."
            },
            [(int)AppResponseCode.InactiveAccount] = new()
            {
                ["en"] = "Inactive account.",
                ["es"] = "Cuenta inactiva."
            },
            [(int)AppResponseCode.LoginAttemptsExceeded] = new()
            {
                ["en"] = "Login attempts exceeded.",
                ["es"] = "Número de intentos de inicio de sesión excedido."
            },

            #endregion

            #region Validation errors (2000-2999)

            [(int)AppResponseCode.ValidationFailed] = new()
            {
                ["en"] = "Validation failed.",
                ["es"] = "Validación fallida."
            },
            [(int)AppResponseCode.MissingRequiredField] = new()
            {
                ["en"] = "Missing required field.",
                ["es"] = "Falta un campo obligatorio."
            },
            [(int)AppResponseCode.InvalidEmailFormat] = new()
            {
                ["en"] = "Invalid email format.",
                ["es"] = "Formato de email inválido."
            },
            [(int)AppResponseCode.PasswordTooWeak] = new()
            {
                ["en"] = "Password too weak.",
                ["es"] = "Contraseña demasiado débil."
            },
            [(int)AppResponseCode.InvalidDateFormat] = new()
            {
                ["en"] = "Invalid date format.",
                ["es"] = "Formato de fecha inválido."
            },
            [(int)AppResponseCode.InvalidPhoneNumberFormat] = new()
            {
                ["en"] = "Invalid phone number format.",
                ["es"] = "Formato de número de teléfono inválido."
            },
            [(int)AppResponseCode.MaxLengthExceeded] = new()
            {
                ["en"] = "Maximum length exceeded.",
                ["es"] = "Se excedió la longitud máxima."
            },
            [(int)AppResponseCode.MinLengthNotReached] = new()
            {
                ["en"] = "Minimum length not reached.",
                ["es"] = "No se alcanzó la longitud mínima."
            },
            [(int)AppResponseCode.InvalidUsernameFormat] = new()
            {
                ["en"] = "Invalid username format.",
                ["es"] = "Formato de nombre de usuario inválido."
            },
            [(int)AppResponseCode.FieldTooLong] = new()
            {
                ["en"] = "Field too long.",
                ["es"] = "Campo demasiado largo."
            },
            [(int)AppResponseCode.InvalidAddressFormat] = new()
            {
                ["en"] = "Invalid address format.",
                ["es"] = "Formato de dirección inválido."
            },

            #endregion

            #region Database errors (3000-3999)

            [(int)AppResponseCode.DatabaseError] = new()
            {
                ["en"] = "Database error.",
                ["es"] = "Error en la base de datos."
            },
            [(int)AppResponseCode.DatabaseConnectionFailed] = new()
            {
                ["en"] = "Database connection failed.",
                ["es"] = "Conexión a la base de datos fallida."
            },
            [(int)AppResponseCode.RecordNotFoundInDatabase] = new()
            {
                ["en"] = "Record not found in database.",
                ["es"] = "Registro no encontrado en la base de datos."
            },
            [(int)AppResponseCode.QueryExecutionFailed] = new()
            {
                ["en"] = "Query execution failed.",
                ["es"] = "La ejecución de la consulta falló."
            },
            [(int)AppResponseCode.RecordAlreadyExists] = new()
            {
                ["en"] = "Record already exists.",
                ["es"] = "El registro ya existe."
            },
            [(int)AppResponseCode.ForeignKeyViolation] = new()
            {
                ["en"] = "Foreign key violation.",
                ["es"] = "Violación de clave externa."
            },
            [(int)AppResponseCode.DatabaseTimeout] = new()
            {
                ["en"] = "Database timeout.",
                ["es"] = "Tiempo de espera de la base de datos agotado."
            },

            #endregion

            #region External service errors (4000-4999)

            [(int)AppResponseCode.ExternalServiceError] = new()
            {
                ["en"] = "External service error.",
                ["es"] = "Error en el servicio externo."
            },
            [(int)AppResponseCode.PaymentServiceError] = new()
            {
                ["en"] = "Payment service error.",
                ["es"] = "Error en el servicio de pagos."
            },
            [(int)AppResponseCode.ThirdPartyApiError] = new()
            {
                ["en"] = "Third-party API error.",
                ["es"] = "Error en API de terceros."
            },
            [(int)AppResponseCode.EmailServiceError] = new()
            {
                ["en"] = "Email service error.",
                ["es"] = "Error en el servicio de correo electrónico."
            },
            [(int)AppResponseCode.SmsServiceError] = new()
            {
                ["en"] = "SMS service error.",
                ["es"] = "Error en el servicio de SMS."
            },
            [(int)AppResponseCode.FileStorageServiceError] = new()
            {
                ["en"] = "File storage service error.",
                ["es"] = "Error en el servicio de almacenamiento de archivos."
            },
            [(int)AppResponseCode.ExternalApiRateLimitExceeded] = new()
            {
                ["en"] = "External API rate limit exceeded.",
                ["es"] = "Límite de tasa de API externo excedido."
            },
            [(int)AppResponseCode.ExternalServiceTimeout] = new()
            {
                ["en"] = "External service timeout.",
                ["es"] = "Tiempo de espera agotado en el servicio externo."
            },

            #endregion

            #region Processing errors (5000-5999)

            [(int)AppResponseCode.ProcessTimeout] = new()
            {
                ["en"] = "Process timeout.",
                ["es"] = "Tiempo de espera del proceso agotado."
            },
            [(int)AppResponseCode.FileUploadFailed] = new()
            {
                ["en"] = "File upload failed.",
                ["es"] = "La carga del archivo falló."
            },
            [(int)AppResponseCode.InsufficientPermissions] = new()
            {
                ["en"] = "Insufficient permissions.",
                ["es"] = "Permisos insuficientes."
            },
            [(int)AppResponseCode.OperationNotSupported] = new()
            {
                ["en"] = "Operation not supported.",
                ["es"] = "Operación no soportada."
            },
            [(int)AppResponseCode.InvalidFileFormat] = new()
            {
                ["en"] = "Invalid file format.",
                ["es"] = "Formato de archivo inválido."
            },
            [(int)AppResponseCode.FileTooLarge] = new()
            {
                ["en"] = "File too large.",
                ["es"] = "Archivo demasiado grande."
            },
            [(int)AppResponseCode.ServerError] = new()
            {
                ["en"] = "Server error.",
                ["es"] = "Error del servidor."
            },
            [(int)AppResponseCode.UnknownInternalError] = new()
            {
                ["en"] = "Unknown internal error.",
                ["es"] = "Error interno desconocido."
            },
            [(int)AppResponseCode.DiskSpaceExceeded] = new()
            {
                ["en"] = "Disk space exceeded.",
                ["es"] = "Espacio en disco excedido."
            },
            [(int)AppResponseCode.MemoryLimitExceeded] = new()
            {
                ["en"] = "Memory limit exceeded.",
                ["es"] = "Límite de memoria excedido."
            },
            [(int)AppResponseCode.TooManyRequests] = new()
            {
                ["en"] = "Too many requests.",
                ["es"] = "Demasiadas solicitudes."
            },
            [(int)AppResponseCode.InvalidApiKey] = new()
            {
                ["en"] = "Invalid API key.",
                ["es"] = "Clave API inválida."
            },

            #endregion

            #region Success messages (6000-6999)

            [(int)AppResponseCode.OperationCompletedSuccessfully] = new()
            {
                ["en"] = "Operation completed successfully.",
                ["es"] = "Operación completada con éxito."
            },
            [(int)AppResponseCode.UserCreatedSuccessfully] = new()
            {
                ["en"] = "User created successfully.",
                ["es"] = "Usuario creado con éxito."
            },
            [(int)AppResponseCode.DataUpdatedSuccessfully] = new()
            {
                ["en"] = "Data updated successfully.",
                ["es"] = "Datos actualizados con éxito."
            },
            [(int)AppResponseCode.FileUploadedSuccessfully] = new()
            {
                ["en"] = "File uploaded successfully.",
                ["es"] = "Archivo subido con éxito."
            },
            [(int)AppResponseCode.PaymentProcessedSuccessfully] = new()
            {
                ["en"] = "Payment processed successfully.",
                ["es"] = "Pago procesado con éxito."
            },
            [(int)AppResponseCode.AuthenticationSuccessful] = new()
            {
                ["en"] = "Authentication successful.",
                ["es"] = "Autenticación exitosa."
            },
            [(int)AppResponseCode.RecordDeletedSuccessfully] = new()
            {
                ["en"] = "Record deleted successfully.",
                ["es"] = "Registro eliminado con éxito."
            },
            [(int)AppResponseCode.PasswordChangedSuccessfully] = new()
            {
                ["en"] = "Password changed successfully.",
                ["es"] = "Contraseña cambiada con éxito."
            },
            [(int)AppResponseCode.EmailVerifiedSuccessfully] = new()
            {
                ["en"] = "Email verified successfully.",
                ["es"] = "Email verificado con éxito."
            },
            [(int)AppResponseCode.AccountActivatedSuccessfully] = new()
            {
                ["en"] = "Account activated successfully.",
                ["es"] = "Cuenta activada con éxito."
            },
            [(int)AppResponseCode.EmailSentSuccessfully] = new()
            {
                ["en"] = "Email sent successfully.",
                ["es"] = "Correo electrónico enviado con éxito."
            },
            [(int)AppResponseCode.DataExportedSuccessfully] = new()
            {
                ["en"] = "Data exported successfully.",
                ["es"] = "Datos exportados con éxito."
            },
            [(int)AppResponseCode.LoginSuccessful] = new()
            {
                ["en"] = "Login successful.",
                ["es"] = "Inicio de sesión exitoso."
            },

            #endregion

            #region Token-related errors (7000-7999)

            [(int)AppResponseCode.TokenExpired] = new()
            {
                ["en"] = "Token expired.",
                ["es"] = "Token expirado."
            },
            [(int)AppResponseCode.TokenInvalid] = new()
            {
                ["en"] = "Token invalid.",
                ["es"] = "Token inválido."
            },
            [(int)AppResponseCode.TokenGenerationFailed] = new()
            {
                ["en"] = "Token generation failed.",
                ["es"] = "Error al generar el token."
            },
            [(int)AppResponseCode.TokenRevoked] = new()
            {
                ["en"] = "Token revoked.",
                ["es"] = "Token revocado."
            },
            [(int)AppResponseCode.TokenNotFound] = new()
            {
                ["en"] = "Token not found.",
                ["es"] = "Token no encontrado."
            },
            [(int)AppResponseCode.TokenAlreadyUsed] = new()
            {
                ["en"] = "Token already used.",
                ["es"] = "Token ya utilizado."
            },
            [(int)AppResponseCode.TokenKeyTooShort] = new()
            {
                ["en"] = "JWT key must be at least 16 characters long.",
                ["es"] = "La clave JWT debe tener al menos 16 caracteres."
            },
            [(int)AppResponseCode.TokenNotExpiredYet] = new()
            {
                ["en"] = "Token not expired yet.",
                ["es"] = "El token aún no ha expirado."
            },
            [(int)AppResponseCode.TokenRenewed] = new()
            {
                ["en"] = "Token renewed.",
                ["es"] = "Token renovado."
            },
            [(int)AppResponseCode.TokenCannotBeRenewed] = new()
            {
                ["en"] = "Token cannot be renewed.",
                ["es"] = "El token no puede ser renovado."
            },
            [(int)AppResponseCode.TokenGeneratedSuccessfully] = new()
            {
                ["en"] = "Token generated successfully.",
                ["es"] = "Token generado con éxito."
            },
            [(int)AppResponseCode.MissingTokenAndUserData] = new()
            {
                ["en"] = "Invalid request. Token and user data must be provided.",
                ["es"] = "Solicitud inválida. Se deben proporcionar el token y los datos del usuario."
            },

            #endregion

            #region Generic unknown errors

            [(int)AppResponseCode.UnknownError] = new()
            {
                ["en"] = "An unknown error occurred.",
                ["es"] = "Ocurrió un error desconocido."
            },
            [(int)AppResponseCode.InternalServerError] = new()
            {
                ["en"] = "Internal server error.",
                ["es"] = "Error interno del servidor."
            },
            [(int)AppResponseCode.ServiceUnavailable] = new()
            {
                ["en"] = "Service unavailable.",
                ["es"] = "Servicio no disponible."
            }

            #endregion
        };

        public static string GetMessage(AppResponseCode code, string language = LanguageCodes.Inglés)
        {
            // Try to get the dictionary of messages for the response code
            if (Messages.TryGetValue((int)code, out var localizedMessages))
            {
                // Try to get the message in the requested language
                if (localizedMessages.TryGetValue(language, out var message))
                {
                    return message;
                }
                // Fallback to English if the specific language is not found
                else if (localizedMessages.TryGetValue(LanguageCodes.Inglés, out var defaultMessage))
                {
                    return defaultMessage;
                }
            }

            // Throw exception if no message is found
            throw new KeyNotFoundException($"No message found for response code '{code}' and language '{language}'.");
        }
    }
}