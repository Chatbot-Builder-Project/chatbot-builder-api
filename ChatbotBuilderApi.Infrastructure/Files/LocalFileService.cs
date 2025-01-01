using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Infrastructure.Files;

public sealed class LocalFileService : IFileService
{
    private readonly string _storageRoot;

    public LocalFileService(string storageRoot)
    {
        if (string.IsNullOrWhiteSpace(storageRoot))
        {
            throw new ArgumentException("Storage root must be provided.", nameof(storageRoot));
        }

        _storageRoot = storageRoot;

        if (!Directory.Exists(_storageRoot))
        {
            Directory.CreateDirectory(_storageRoot);
        }
    }

    public async Task<string> UploadFileAsync(FileUpload fileUpload)
    {
        if (fileUpload.FileStream == null || fileUpload.FileStream.Length == 0)
        {
            throw new ArgumentException("Invalid file upload.");
        }

        var uniqueFileName = $"{Guid.NewGuid()}_{fileUpload.FileName}";
        var filePath = Path.Combine(_storageRoot, uniqueFileName);

        await using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        await fileUpload.FileStream.CopyToAsync(fileStream);

        return filePath;
    }

    public Task<bool> DeleteFileAsync(string fileUrl)
    {
        if (string.IsNullOrWhiteSpace(fileUrl))
        {
            throw new ArgumentException("File URL must be provided.");
        }

        try
        {
            if (!File.Exists(fileUrl))
            {
                return Task.FromResult(false);
            }

            File.Delete(fileUrl);
            return Task.FromResult(true);
        }
        catch (Exception)
        {
            return Task.FromResult(false);
        }
    }
}