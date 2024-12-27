using ChatbotBuilderApi.Presentation.Graphs.Data;

namespace ChatbotBuilderApi.Presentation.Conversations.Messages.Requests;

public sealed record SendMessageRequest(
    TextDataModel? Text,
    OptionDataModel? Option);