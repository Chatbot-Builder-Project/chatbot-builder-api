using ChatbotBuilderApi.Application.Core.Shared.Responses;

namespace ChatbotBuilderApi.Presentation.Chatbots.ViewModels;

public class ChatbotListViewModel
{
    public required PageResponse<ChatbotViewModel> Chatbots { get; set; }
}