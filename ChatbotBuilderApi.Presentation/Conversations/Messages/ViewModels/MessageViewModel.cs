using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderApi.Presentation.Graphs.Data;

namespace ChatbotBuilderApi.Presentation.Conversations.Messages.ViewModels;

/// <summary>
/// View model for a user message.
/// </summary>
/// <param name="CreatedAt">Date and time the message was created.</param>
/// <param name="Text">Text input data. If any.</param>
/// <param name="Option">Option input data. If any.</param>
public sealed record InputMessageViewModel(
    DateTime CreatedAt,
    TextDataModel? Text,
    OptionDataModel? Option);

/// <summary>
/// View model for a system response message.
/// </summary>
/// <param name="CreatedAt">Date and time the message was created.</param>
/// <param name="TextOutput">Text output data. If any.</param>
/// <param name="TextExpected">Whether a text input is expected on the next user message.</param>
/// <param name="OptionExpected">Whether an option input is expected on the next user message.</param>
/// <param name="ExpectedOptionMetas">If an option input is expected,
/// use these option metas to display the options to the user.</param>
public sealed record OutputMessageViewModel(
    DateTime CreatedAt,
    TextDataModel? TextOutput,
    bool TextExpected,
    bool OptionExpected,
    IReadOnlyDictionary<OptionDataModel, InteractionOptionMeta>? ExpectedOptionMetas);