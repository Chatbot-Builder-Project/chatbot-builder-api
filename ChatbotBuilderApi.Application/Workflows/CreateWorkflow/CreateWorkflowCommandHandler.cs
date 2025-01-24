using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Application.Graphs;
using ChatbotBuilderApi.Domain.Workflows;

namespace ChatbotBuilderApi.Application.Workflows.CreateWorkflow;

public sealed class CreateWorkflowCommandHandler : ICommandHandler<CreateWorkflowCommand, CreateResponse<WorkflowId>>
{
    private readonly IWorkflowRepository _workflowRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWorkflowCommandHandler(
        IWorkflowRepository workflowRepository,
        IUnitOfWork unitOfWork)
    {
        _workflowRepository = workflowRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CreateResponse<WorkflowId>>> Handle(
        CreateWorkflowCommand request,
        CancellationToken cancellationToken)
    {
        var workflow = Workflow.Create(
            new WorkflowId(Guid.NewGuid()),
            request.Name,
            request.Description,
            request.OwnerId,
            request.Graph.ToDomain(),
            request.Visual);

        _workflowRepository.Add(workflow);

        await _unitOfWork.CommitAsync(cancellationToken);

        var result = new CreateResponse<WorkflowId>(workflow.Id);
        return Result.Success(result);
    }
}