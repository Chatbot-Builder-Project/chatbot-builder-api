using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Presentation.Graphs.Data;

namespace ChatbotBuilderApi.Presentation.Chatbots.ViewModels;

/// <summary>
/// A list of chatbots.
/// </summary>
/// <param name="Page"></param>
public sealed record ChatbotListViewModel(PageResponse<ChatbotListViewModelItem> Page);

/// <summary>
/// Item in the list of chatbots.
/// </summary>
/// <param name="Id">ID of the chatbot.</param>
/// <param name="OwnerId">ID of the owner of the chatbot.</param>
/// <param name="CreatedAt">Date and time when the chatbot was created.</param>
/// <param name="UpdatedAt">Date and time when the chatbot was last updated.</param>
/// <param name="Name">Name of the chatbot.</param>
/// <param name="Description">Description of the chatbot.</param>
/// <param name="IsPublic">Whether the chatbot is publicly available.</param>
/// <param name="AvatarImage">(Optional) Avatar image of the chatbot.</param>
public sealed record ChatbotListViewModelItem(
    Guid Id,
    Guid OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    bool IsPublic,
    ImageDataModel? AvatarImage);