using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Switch.Smart;

public interface ISmartRoutingService
{
    /// <returns>OptionData or null if the service chooses to fallback.</returns>
    Task<OptionData?> RouteAsync(
        TextData input,
        IReadOnlySet<OptionData> options,
        CancellationToken cancellationToken);
}