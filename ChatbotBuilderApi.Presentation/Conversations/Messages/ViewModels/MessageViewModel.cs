using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderApi.Presentation.Graphs.Data;

namespace ChatbotBuilderApi.Presentation.Conversations.Messages.ViewModels;

public sealed record InputMessageViewModel(
    DateTime CreatedAt,
    TextDataModel? Text,
    OptionDataModel? Option);

public sealed record OutputMessageViewModel(
    DateTime CreatedAt,
    TextDataModel? TextOutput,
    bool TextExpected,
    bool OptionExpected,
    IReadOnlyDictionary<OptionDataModel, InteractionOptionMeta>? ExpectedOptionMetas);