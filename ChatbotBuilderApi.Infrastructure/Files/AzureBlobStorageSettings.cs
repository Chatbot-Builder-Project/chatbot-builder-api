namespace ChatbotBuilderApi.Infrastructure.Files;

public sealed class AzureBlobStorageSettings
{
    public required string AccountName { get; init; }
    public required string AccountKey { get; init; }
    public required string ContainerName { get; init; }
}