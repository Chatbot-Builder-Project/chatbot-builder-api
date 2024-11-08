using ChatbotBuilderApi.Domain.Shared;

namespace ChatbotBuilderApi.Presentation.Constants;

public static class PresentationRules
{
    public static Error AuthenticationFailed(string message) => new(
        ErrorType.NotAuthorized,
        "Authorization Failed",
        message);
}