using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Graphs;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Workflows.GetWorkflow;

public sealed class GetWorkflowQueryHandler : IQueryHandler<GetWorkflowQuery, GetWorkflowResponse>
{
    private readonly IWorkflowRepository _repository;

    public GetWorkflowQueryHandler(IWorkflowRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetWorkflowResponse>> Handle(GetWorkflowQuery request, CancellationToken cancellationToken)
    {
        var workflow = await _repository.GetByIdAndUserAsync(
            request.Id,
            request.OwnerId,
            includeGraph: true,
            cancellationToken);

        if (workflow is null)
        {
            return Result.Failure<GetWorkflowResponse>(WorkflowsApplicationErrors.WorkflowNotFound);
        }

        var response = new GetWorkflowResponse(
            workflow.Id,
            new UserId(workflow.OwnerId),
            workflow.CreatedAt,
            workflow.UpdatedAt,
            workflow.Name,
            workflow.Description,
            workflow.Graph.ToDto());

        return Result.Success(response);
    }
}