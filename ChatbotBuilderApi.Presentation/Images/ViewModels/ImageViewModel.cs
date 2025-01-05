namespace ChatbotBuilderApi.Presentation.Images.ViewModels;

/// <summary>
/// Image view model.
/// </summary>
/// <param name="Id">ID of the image.</param>
/// <param name="CreatedAt">Date and time the image was created.</param>
/// <param name="UpdatedAt">Date and time the image was last updated.</param>
/// <param name="Url">URL of the image.</param>
/// <param name="Name">Name of the image.</param>
/// <param name="ContentType">Content type of the image.</param>
/// <param name="IsProfilePicture">Whether the image is a profile picture.</param>
public sealed record ImageViewModel(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Url,
    string Name,
    string ContentType,
    bool IsProfilePicture);