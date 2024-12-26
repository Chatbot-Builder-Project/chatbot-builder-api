namespace ChatbotBuilderApi.Domain.Core.Primitives;

public sealed class Error : ValueObject
{
    public ErrorType Type { get; } = ErrorType.None;
    public string Code { get; } = string.Empty;
    public string Message { get; } = string.Empty;

    private Error(ErrorType type, string code, string message)
    {
        Type = type;
        Code = code;
        Message = message;
    }

    /// <inheritdoc/>
    private Error()
    {
    }

    public static implicit operator string(Error? error) => error?.Code ?? string.Empty;

    /// <inheritdoc/>
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Type;
        yield return Code;
        yield return Message;
    }

    public static readonly Error None = new(
        ErrorType.None,
        string.Empty,
        string.Empty);

    public static Error DomainInvariant(string code, string message) =>
        new(ErrorType.DomainInvariant, code, message);

    public static Error ApplicationValidation(string code, string message) =>
        new(ErrorType.ApplicationValidation, code, message);

    public static Error BadRequest(string code, string message) =>
        new(ErrorType.BadRequest, code, message);

    public static Error NotFound(string code, string message) =>
        new(ErrorType.NotFound, code, message);

    public static Error NotAuthorized(string code, string message) =>
        new(ErrorType.NotAuthorized, code, message);

    public static Error Conflict(string code, string message) =>
        new(ErrorType.Conflict, code, message);

    public static Error InternalServerError(string code, string message) =>
        new(ErrorType.InternalServerError, code, message);

    public static Error Forbidden(string code, string message) =>
        new(ErrorType.Forbidden, code, message);

    public static Error TooManyRequests(string code, string message) =>
        new(ErrorType.TooManyRequests, code, message);
}

public enum ErrorType
{
    None,
    DomainInvariant,
    ApplicationValidation,
    BadRequest,
    NotFound,
    NotAuthorized,
    Conflict,
    InternalServerError,
    Forbidden,
    TooManyRequests
}