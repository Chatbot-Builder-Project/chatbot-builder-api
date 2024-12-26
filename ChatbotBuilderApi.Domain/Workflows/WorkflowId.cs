using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Workflows;

public sealed class WorkflowId : EntityId<WorkflowId>
{
    public WorkflowId(Guid value) : base(value)
    {
    }
}