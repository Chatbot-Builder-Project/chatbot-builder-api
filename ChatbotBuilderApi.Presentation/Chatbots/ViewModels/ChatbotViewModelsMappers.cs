using ChatbotBuilderApi.Application.Chatbots.GetChatbot;
using ChatbotBuilderApi.Application.Chatbots.ListChatbots;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Chatbots.ViewModels;

[Mapper]
public static partial class ChatbotViewModelsMappers
{
    public static partial ChatbotViewModel ToViewModel(this GetChatbotResponse chatbot);

    public static partial ChatbotListViewModel ToViewModel(this ListChatbotsResponse chatbots);
}