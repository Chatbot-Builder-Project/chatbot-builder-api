using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Presentation.Core;

public static class PresentationErrors
{
    public static Error AuthenticationFailed(string message) =>
        Error.NotAuthorized("Authorization Failed", message);
}