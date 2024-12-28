using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Workflows.UpdateWorkflow;

public sealed record WorkflowUpdatedEvent(
    WorkflowId WorkflowId,
    UserId OwnerId
) : IEvent;