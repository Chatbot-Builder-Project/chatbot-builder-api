namespace ChatbotBuilderApi.Presentation.Images.Requests;

/// <summary>
/// Request to update an image.
/// </summary>
/// <param name="IsProfilePicture">Whether the image is a profile picture.</param>
public sealed record UpdateImageRequest(bool IsProfilePicture);