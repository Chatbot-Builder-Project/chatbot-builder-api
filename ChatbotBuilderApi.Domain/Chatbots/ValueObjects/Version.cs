using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Chatbots.ValueObjects;

public sealed class Version : ValueObject
{
    public int Major { get; }

    private Version(int major)
    {
        Major = major;
    }

    /// <inheritdoc/>
    private Version()
    {
    }

    public static Version Create(int major)
    {
        if (major < 1)
        {
            throw new DomainException(ChatbotDomainErrors.Version.MajorMustBePositive);
        }

        return new Version(major);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Major;
    }
}