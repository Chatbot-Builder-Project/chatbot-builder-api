using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;

/// <summary>
/// Contains all data that should be outputted to the user.
/// And contains guiding information for what the user should input next.
/// </summary>
public sealed class InteractionOutput : ValueObject
{
    public TextData? TextOutput { get; }
    public IReadOnlyList<ImageData> ImageOutputs { get; } = null!;
    public bool TextExpected { get; }
    public bool OptionExpected { get; }
    public IReadOnlyDictionary<OptionData, InteractionOptionMeta>? ExpectedOptionMetas { get; }

    private InteractionOutput(
        TextData? textOutput,
        IReadOnlyList<ImageData> imageOutputs,
        bool textExpected,
        bool optionExpected,
        IReadOnlyDictionary<OptionData, InteractionOptionMeta>? expectedOptionMetas)
    {
        TextOutput = textOutput;
        ImageOutputs = imageOutputs;
        TextExpected = textExpected;
        OptionExpected = optionExpected;
        ExpectedOptionMetas = expectedOptionMetas;
    }

    /// <inheritdoc/>
    private InteractionOutput()
    {
    }

    public static InteractionOutput Create(
        TextData? textOutput,
        IReadOnlyList<ImageData> imageOutputs,
        bool textExpected,
        bool optionExpected,
        IReadOnlyDictionary<OptionData, InteractionOptionMeta>? expectedOptionsMetas)
    {
        return new InteractionOutput(textOutput, imageOutputs, textExpected, optionExpected, expectedOptionsMetas);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return (object?)TextOutput ?? false;

        foreach (var imageOutput in ImageOutputs)
        {
            yield return imageOutput;
        }

        yield return TextExpected;
        yield return OptionExpected;
        yield return (object?)ExpectedOptionMetas ?? false;
    }
}