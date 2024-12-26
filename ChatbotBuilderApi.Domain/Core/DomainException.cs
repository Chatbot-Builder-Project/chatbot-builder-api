using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Core;

public sealed class DomainException : Exception
{
    public Error Error { get; }

    public DomainException(Error error) : base(error.Message)
    {
        Error = error;
    }
}