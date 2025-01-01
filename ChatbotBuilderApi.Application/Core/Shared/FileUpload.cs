namespace ChatbotBuilderApi.Application.Core.Shared;

public sealed record FileUpload(
    string FileName,
    string ContentType,
    Stream FileStream);