namespace LiquidacionPeajesNew.Domain.Enums
{
    /*
        Error code ranges:
            1000-1999: User-related errors (e.g., not found, invalid credentials).
            2000-2999: Validation errors (e.g., missing fields, invalid format).
            3000-3999: Database errors (e.g., connection issues, record not found).
            4000-4999: External service errors (e.g., payment services, third-party APIs).
            5000-5999: Processing errors (e.g., timeouts, file uploads).
            6000-6999: Success messages (e.g., operations completed, user created).
            7000-7999: Token-related errors (e.g., expired, invalid).
            9999: Generic unknown error.
    */

    public enum AppResponseCode
    {
        // User-related errors
        UserNotFound = 1000,
        InvalidInput = 1001,
        InvalidCredentials = 1002,
        AccountLocked = 1003,
        InvalidToken = 1004,
        UnauthorizedAction = 1005,
        UserAlreadyExists = 1006,
        EmailNotVerified = 1007,
        UserSuspended = 1008,
        InvalidPhoneNumber = 1009,
        UserBanned = 1010,

        // Login-specific errors
        IncorrectPassword = 1011,
        InactiveAccount = 1012,
        LoginAttemptsExceeded = 1013,

        // Validation errors
        ValidationFailed = 2000,
        MissingRequiredField = 2001,
        InvalidEmailFormat = 2002,
        PasswordTooWeak = 2003,
        InvalidDateFormat = 2004,
        InvalidPhoneNumberFormat = 2005,
        MaxLengthExceeded = 2006,
        MinLengthNotReached = 2007,
        InvalidUsernameFormat = 2008,
        FieldTooLong = 2009,
        InvalidAddressFormat = 2010,

        // Database errors
        DatabaseError = 3000,
        DatabaseConnectionFailed = 3001,
        RecordNotFoundInDatabase = 3002,
        QueryExecutionFailed = 3003,
        RecordAlreadyExists = 3004,
        ForeignKeyViolation = 3005,
        DatabaseTimeout = 3006,

        // External service errors
        ExternalServiceError = 4000,
        PaymentServiceError = 4001,
        ThirdPartyApiError = 4002,
        EmailServiceError = 4003,
        SmsServiceError = 4004,
        FileStorageServiceError = 4005,
        ExternalApiRateLimitExceeded = 4006,
        ExternalServiceTimeout = 4007,

        // Processing errors
        ProcessTimeout = 5000,
        FileUploadFailed = 5001,
        InsufficientPermissions = 5002,
        OperationNotSupported = 5003,
        InvalidFileFormat = 5004,
        FileTooLarge = 5005,
        ServerError = 5006,
        UnknownInternalError = 5007,
        DiskSpaceExceeded = 5008,
        MemoryLimitExceeded = 5009,
        TooManyRequests = 5010,
        InvalidApiKey = 5011,

        // Success messages
        OperationCompletedSuccessfully = 6000,
        UserCreatedSuccessfully = 6001,
        DataUpdatedSuccessfully = 6002,
        FileUploadedSuccessfully = 6003,
        PaymentProcessedSuccessfully = 6004,
        AuthenticationSuccessful = 6005,
        RecordDeletedSuccessfully = 6006,
        PasswordChangedSuccessfully = 6007,
        EmailVerifiedSuccessfully = 6008,
        AccountActivatedSuccessfully = 6009,
        EmailSentSuccessfully = 6010,
        DataExportedSuccessfully = 6011,
        LoginSuccessful = 6012,

        // Token-related errors
        TokenExpired = 7000,
        TokenInvalid = 7001,
        TokenGenerationFailed = 7002,
        TokenRevoked = 7003,
        TokenNotFound = 7004,
        TokenAlreadyUsed = 7005,
        TokenKeyTooShort = 7006,
        TokenNotExpiredYet = 7007,
        TokenRenewed = 7008,
        TokenCannotBeRenewed = 7009,
        TokenGeneratedSuccessfully = 7010,
        MissingTokenAndUserData = 7011,

        // Generic unknown errors
        UnknownError = 9999,
        InternalServerError = 9998,
        ServiceUnavailable = 9997
    }
}