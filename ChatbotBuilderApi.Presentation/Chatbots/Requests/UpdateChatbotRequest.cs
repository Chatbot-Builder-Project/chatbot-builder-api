using ChatbotBuilderApi.Presentation.Graphs.Data;
using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Chatbots.Requests;

/// <summary>
/// Request to update a chatbot.
/// </summary>
/// <param name="Name">Name of the chatbot.</param>
/// <param name="Description">Description of the chatbot.</param>
/// <param name="IsPublic">Whether the chatbot is publicly available.</param>
/// <param name="AvatarImage">(Optional) Avatar image of the chatbot.</param>
/// <param name="Visual">Generic visual metadata of the chatbot.</param>
public sealed record UpdateChatbotRequest(
    string Name,
    string Description,
    bool IsPublic,
    ImageDataModel? AvatarImage,
    VisualMetaModel Visual);