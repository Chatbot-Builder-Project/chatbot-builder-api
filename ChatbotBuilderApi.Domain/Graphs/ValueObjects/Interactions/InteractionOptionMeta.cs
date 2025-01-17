using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;

/// <summary>
/// Meta information for an OptionData used in an Interaction node
/// </summary>
public sealed class InteractionOptionMeta : ValueObject
{
    public string Description { get; } = null!;
    public ImageData? ImageData { get; }

    private InteractionOptionMeta(
        string description,
        ImageData? imageData)
    {
        Description = description;
        ImageData = imageData;
    }

    /// <inheritdoc/>
    private InteractionOptionMeta()
    {
    }

    public static InteractionOptionMeta Create(string description, ImageData? imageData) =>
        new(description, imageData);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Description;
        yield return (object?)ImageData ?? false;
    }
}