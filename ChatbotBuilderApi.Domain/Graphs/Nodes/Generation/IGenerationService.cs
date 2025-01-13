using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;

public interface IGenerationService
{
    Task<TextData> GenerateAsync(
        TextData input,
        GenerationOptions options,
        Guid contextId,
        CancellationToken cancellationToken);
}