using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Workflows.DeleteWorkflow;

public sealed record WorkflowDeletedEvent(
    WorkflowId WorkflowId,
    UserId OwnerId
) : IEvent;