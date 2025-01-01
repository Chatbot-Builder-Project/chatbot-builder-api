namespace ChatbotBuilderApi.Presentation.Images.ViewModels;

public sealed record ImageViewModel(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Url,
    string Name,
    string ContentType,
    bool IsProfilePicture);