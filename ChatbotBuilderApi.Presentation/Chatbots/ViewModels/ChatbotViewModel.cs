using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using Version = ChatbotBuilderApi.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderApi.Presentation.Chatbots.ViewModels;

/// <summary>
/// View model for a chatbot.
/// </summary>
/// <param name="Id">ID of the chatbot.</param>
/// <param name="OwnerId">ID of the owner of the chatbot.</param>
/// <param name="CreatedAt">Date and time when the chatbot was created.</param>
/// <param name="UpdatedAt">Date and time when the chatbot was last updated.</param>
/// <param name="Name">Name of the chatbot.</param>
/// <param name="Description">Description of the chatbot.</param>
/// <param name="AvatarImage">(Optional) Avatar image of the chatbot.</param>
/// <param name="Visual">Generic visual metadata of the chatbot.</param>
/// <param name="AdminDetails">Admin details of the chatbot.</param>
public sealed record ChatbotViewModel(
    Guid Id,
    Guid OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    ImageDataModel? AvatarImage,
    VisualMetaModel Visual,
    ChatbotViewModelAdminDetails? AdminDetails);

/// <summary>
/// Admin details of the chatbot.
/// </summary>
/// <param name="Version">Version of the chatbot.</param>
/// <param name="WorkflowId">ID of the workflow the chatbot is part of.</param>
/// <param name="IsPublic">Whether the chatbot is publicly available.</param>
/// <param name="IsLatest">Whether the chatbot is the latest version of the chatbot in the workflow.</param>
public sealed record ChatbotViewModelAdminDetails(
    Version Version,
    Guid WorkflowId,
    bool IsPublic,
    bool IsLatest);