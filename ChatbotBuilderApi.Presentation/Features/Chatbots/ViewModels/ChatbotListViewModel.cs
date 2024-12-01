using ChatbotBuilderApi.Application.Shared;

namespace ChatbotBuilderApi.Presentation.Features.Chatbots.ViewModels;

public class ChatbotListViewModel
{
    public required PageResponse<ChatbotViewModel> Chatbots { get; set; }
}