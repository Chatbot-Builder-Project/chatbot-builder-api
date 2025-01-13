using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Application.Core.Exceptions;

public sealed class ExternalException : Exception
{
    public Error Error { get; }

    public ExternalException(Error error) : base(error.Message)
    {
        Error = error;
    }
}