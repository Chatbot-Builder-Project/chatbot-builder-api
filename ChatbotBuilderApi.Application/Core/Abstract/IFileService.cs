using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Core.Abstract;

public interface IFileService
{
    /// <returns>The URL of the uploaded file.</returns>
    Task<string> UploadFileAsync(FileUpload fileUpload);

    Task<bool> DeleteFileAsync(string fileUrl);
}