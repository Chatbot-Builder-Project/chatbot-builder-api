using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Workflows.GetWorkflow;

public sealed class GetWorkflowQuery : IQuery<GetWorkflowResponse>
{
    public required WorkflowId Id { get; init; }
    public required UserId OwnerId { get; init; }
    public required bool IncludeStats { get; init; }
}