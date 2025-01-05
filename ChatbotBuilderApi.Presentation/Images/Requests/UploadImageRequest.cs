using Microsoft.AspNetCore.Http;

namespace ChatbotBuilderApi.Presentation.Images.Requests;

/// <summary>
/// Request to upload an image.
/// </summary>
/// <param name="FileUpload">Image file to upload.</param>
/// <param name="IsProfilePicture">Whether the image is a profile picture.</param>
public sealed record UploadImageRequest(
    IFormFile FileUpload,
    bool? IsProfilePicture);