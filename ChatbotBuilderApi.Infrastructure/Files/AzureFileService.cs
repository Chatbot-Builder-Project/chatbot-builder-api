using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Shared;
using Microsoft.Extensions.Options;

namespace ChatbotBuilderApi.Infrastructure.Files;

public sealed class AzureFileService : IFileService
{
    private readonly BlobContainerClient _containerClient;

    public AzureFileService(IOptions<AzureBlobStorageSettings> options)
    {
        var settings = options.Value ??
                       throw new ArgumentNullException(nameof(options));

        var connectionString = $"DefaultEndpointsProtocol=https;" +
                               $"AccountName={settings.AccountName};" +
                               $"AccountKey={settings.AccountKey};" +
                               $"EndpointSuffix=core.windows.net";

        _containerClient = new BlobContainerClient(connectionString, settings.ContainerName);
        _containerClient.CreateIfNotExists(PublicAccessType.Blob);
    }

    public async Task<string> UploadFileAsync(FileUpload fileUpload)
    {
        var blobName = $"{Guid.NewGuid()}-{fileUpload.FileName}";
        var blobClient = _containerClient.GetBlobClient(blobName);

        await blobClient.UploadAsync(fileUpload.FileStream, new BlobHttpHeaders
        {
            ContentType = fileUpload.ContentType
        });

        return blobClient.Uri.ToString();
    }

    public async Task<bool> DeleteFileAsync(string fileUrl)
    {
        var fileUri = new Uri(fileUrl);
        var blobName = fileUri.Segments[^1];
        var blobClient = _containerClient.GetBlobClient(blobName);
        return await blobClient.DeleteIfExistsAsync();
    }
}