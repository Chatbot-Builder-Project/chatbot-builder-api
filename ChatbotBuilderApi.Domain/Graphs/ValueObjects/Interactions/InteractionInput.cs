using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;

/// <summary>
/// Contains the input data that are collected from the user.
/// </summary>
public sealed class InteractionInput : ValueObject
{
    public TextData? Text { get; }
    public OptionData? Option { get; }

    private InteractionInput(TextData? text, OptionData? option)
    {
        Text = text;
        Option = option;
    }

    /// <inheritdoc/>
    private InteractionInput()
    {
    }

    public static InteractionInput Create(TextData? text, OptionData? option) => new(text, option);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return (object?)Text ?? false;
        yield return (object?)Option ?? false;
    }
}