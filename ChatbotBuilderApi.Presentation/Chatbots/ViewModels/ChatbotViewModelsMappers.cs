using ChatbotBuilderApi.Application.Chatbots.GetChatbot;
using ChatbotBuilderApi.Application.Chatbots.ListChatbots;
using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Presentation.Graphs;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Chatbots.ViewModels;

[Mapper]
public static partial class ChatbotViewModelsMappers
{
    public static ChatbotViewModel ToViewModel(this GetChatbotResponse chatbot)
    {
        return new ChatbotViewModel(
            chatbot.Id,
            chatbot.OwnerId,
            chatbot.CreatedAt,
            chatbot.UpdatedAt,
            chatbot.Name,
            chatbot.Description,
            chatbot.AvatarImageData is null
                ? null
                : new ImageDataModel(chatbot.AvatarImageData.Url),
            chatbot.Visual.ToModel(),
            chatbot.AdminDetails is null
                ? null
                : new ChatbotViewModelAdminDetails(
                    chatbot.AdminDetails.Version,
                    chatbot.AdminDetails.WorkflowId,
                    chatbot.AdminDetails.IsPublic,
                    chatbot.AdminDetails.IsLatest,
                    chatbot.AdminDetails.Graph?.ToModel()),
            chatbot.Stats is null
                ? null
                : new ChatbotViewModelStats(
                    chatbot.Stats.NumberOfUsers,
                    chatbot.Stats.NumberOfConversations,
                    chatbot.Stats.NumberOfMessages));
    }

    public static ChatbotListViewModel ToViewModel(this ListChatbotsResponse chatbots)
    {
        return new ChatbotListViewModel(new PageResponse<ChatbotListViewModelItem>
        {
            TotalCount = chatbots.Page.TotalCount,
            Items = chatbots.Page.Items.Select(x => new ChatbotListViewModelItem(
                x.Id,
                x.OwnerId,
                x.CreatedAt,
                x.UpdatedAt,
                x.Name,
                x.Description,
                x.IsPublic,
                x.AvatarImageData is null
                    ? null
                    : new ImageDataModel(x.AvatarImageData.Url),
                x.Visual.ToModel()
            )).ToList()
        });
    }
}