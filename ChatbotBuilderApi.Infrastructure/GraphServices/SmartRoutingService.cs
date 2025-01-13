using ChatbotBuilderApi.Application.Core.Exceptions;
using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.Nodes.Switch.Smart;
using ChatbotBuilderProtos.V1.Executor;
using OptionData = ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data.OptionData;
using TextData = ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data.TextData;

namespace ChatbotBuilderApi.Infrastructure.GraphServices;

public sealed class SmartRoutingService : ISmartRoutingService
{
    private readonly ExecutorService.ExecutorServiceClient _executorServiceClient;

    public SmartRoutingService(ExecutorService.ExecutorServiceClient executorServiceClient)
    {
        _executorServiceClient = executorServiceClient;
    }

    public async Task<OptionData?> RouteAsync(
        TextData input,
        IReadOnlySet<OptionData> options,
        CancellationToken cancellationToken)
    {
        var request = new RoutingRequest
        {
            Input = new ChatbotBuilderProtos.V1.Executor.TextData { Text = input.Text }
        };

        request.Options.AddRange(options.Select(o =>
            new ChatbotBuilderProtos.V1.Executor.OptionData { Option = o.Value }));

        var response = await _executorServiceClient.RouteAsync(request, cancellationToken: cancellationToken);

        if (response.Error is not null)
        {
            throw new ExternalException(Error.InternalServerError(
                "SmartRoutingService.Route",
                response.Error.Message));
        }

        return response.IsFallback
            ? null
            : OptionData.Create(response.SelectedOption.Option);
    }
}