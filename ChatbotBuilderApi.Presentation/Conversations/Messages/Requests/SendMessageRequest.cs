using ChatbotBuilderApi.Presentation.Graphs.Data;

namespace ChatbotBuilderApi.Presentation.Conversations.Messages.Requests;

/// <summary>
/// User input message request.
/// </summary>
/// <param name="Text">If the previous response requested text input, add the text here.</param>
/// <param name="Option">If the previous response requested an option, add the option here.</param>
public sealed record SendMessageRequest(
    TextDataModel? Text,
    OptionDataModel? Option);