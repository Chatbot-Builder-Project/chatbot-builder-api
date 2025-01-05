namespace ChatbotBuilderApi.Application.Core.Shared.Responses;

public sealed class PageResponse<TItem>
{
    public required int TotalCount { get; init; }
    public required IReadOnlyList<TItem> Items { get; init; }
}