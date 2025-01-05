namespace ChatbotBuilderApi.Presentation.Conversations.Messages.ViewModels;

/// <summary>
/// System response message view model.
/// </summary>
/// <param name="Output">Output message view model.</param>
public sealed record SendMessageViewModel(OutputMessageViewModel Output);