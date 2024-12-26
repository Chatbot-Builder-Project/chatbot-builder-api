using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Application.Workflows;

public static class WorkflowsApplicationErrors
{
    public static readonly Error WorkflowNotFound = Error.NotFound(
        "Workflows.WorkflowNotFound",
        "Workflow not found.");
}