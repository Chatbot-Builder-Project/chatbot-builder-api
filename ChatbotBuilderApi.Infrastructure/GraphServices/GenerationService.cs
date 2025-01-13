using ChatbotBuilderApi.Application.Core.Exceptions;
using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;
using ChatbotBuilderProtos.V1.Executor;
using GenerationOptions = ChatbotBuilderApi.Domain.Graphs.Nodes.Generation.GenerationOptions;
using TextData = ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data.TextData;

namespace ChatbotBuilderApi.Infrastructure.GraphServices;

public sealed class GenerationService : IGenerationService
{
    private readonly ExecutorService.ExecutorServiceClient _executorServiceClient;

    public GenerationService(ExecutorService.ExecutorServiceClient executorServiceClient)
    {
        _executorServiceClient = executorServiceClient;
    }

    public async Task<TextData> GenerateAsync(
        TextData input,
        GenerationOptions options,
        Guid contextId,
        CancellationToken cancellationToken)
    {
        var request = new GenerationRequest
        {
            Input = new ChatbotBuilderProtos.V1.Executor.TextData { Text = input.Text },
            Options = new ChatbotBuilderProtos.V1.Executor.GenerationOptions
            {
                UseMemory = options.UseMemory,
                ResponseJsonSchema = options.ResponseSchema?.ToString() ?? string.Empty
            },
            ContextId = contextId.ToString()
        };

        var response = await _executorServiceClient.GenerateAsync(
            request,
            cancellationToken: cancellationToken);

        if (response.Error is not null)
        {
            throw new ExternalException(Error.InternalServerError(
                "GenerationService.Generate",
                response.Error.Message));
        }

        return TextData.Create(response.GeneratedOutput.Text);
    }
}