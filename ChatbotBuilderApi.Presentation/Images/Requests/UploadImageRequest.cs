using Microsoft.AspNetCore.Http;

namespace ChatbotBuilderApi.Presentation.Images.Requests;

public sealed record UploadImageRequest(
    IFormFile FileUpload,
    bool? IsProfilePicture);