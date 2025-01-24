using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Graphs;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Workflows.UpdateWorkflow;

public sealed class UpdateWorkflowCommand : ICommand
{
    public required WorkflowId Id { get; init; }
    public required UserId OwnerId { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required GraphDto Graph { get; init; }
    public required VisualMeta Visual { get; init; }
}