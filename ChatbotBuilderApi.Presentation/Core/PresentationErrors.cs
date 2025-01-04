using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Presentation.Core;

public static class PresentationErrors
{
    public static class User
    {
        public static readonly Error CredentialsNotProvided = Error.NotAuthorized(
            "User.CredentialsNotProvided",
            "Use credentials not provided.");
    }
}