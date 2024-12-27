using Version = ChatbotBuilderApi.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderApi.Presentation.Chatbots.ViewModels;

public sealed record ChatbotViewModel(
    Guid Id,
    Guid OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    ChatbotViewModelAdminDetails? AdminDetails);

public sealed record ChatbotViewModelAdminDetails(
    Version Version,
    Guid WorkflowId,
    bool IsPublic,
    bool IsLatest);