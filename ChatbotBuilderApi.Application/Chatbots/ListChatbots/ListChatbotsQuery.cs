using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Chatbots.ListChatbots;

public sealed class ListChatbotsQuery : IQuery<ListChatbotsResponse>
{
    public required PageParams PageParams { get; init; }
    public required UserId UserId { get; init; }
    public string? Search { get; init; }
    public bool IncludeOnlyPersonal { get; init; }
    public bool IncludeOnlyLatest { get; init; } = true;
    public WorkflowId? WorkflowId { get; init; }
}