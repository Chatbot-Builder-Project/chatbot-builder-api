using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Workflows.ListWorkflows;

public sealed class ListWorkflowsQuery : IQuery<ListWorkflowsResponse>
{
    public required PageParams PageParams { get; init; }
    public required UserId OwnerId { get; init; }
    public string? Search { get; init; }
}