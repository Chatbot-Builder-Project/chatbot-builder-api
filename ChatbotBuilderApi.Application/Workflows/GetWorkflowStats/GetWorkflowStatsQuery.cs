using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Workflows.GetWorkflowStats;

public sealed class GetWorkflowStatsQuery : IQuery<GetWorkflowStatsResponse>
{
    public required WorkflowId Id { get; init; }
    public required UserId OwnerId { get; init; }
}