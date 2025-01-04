using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Chatbots;

public static class ChatbotDomainErrors
{
    public static class Version
    {
        public static readonly Error MajorMustBePositive = Error.DomainInvariant(
            "Version.MajorMustBePositive",
            "Chatbot major version must be positive.");
    }
}