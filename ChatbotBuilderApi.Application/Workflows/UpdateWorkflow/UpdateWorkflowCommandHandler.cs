using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Graphs;
using MediatR;

namespace ChatbotBuilderApi.Application.Workflows.UpdateWorkflow;

public sealed class UpdateWorkflowCommandHandler : ICommandHandler<UpdateWorkflowCommand>
{
    private readonly IWorkflowRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _publisher;

    public UpdateWorkflowCommandHandler(
        IWorkflowRepository repository,
        IUnitOfWork unitOfWork,
        IPublisher publisher)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _publisher = publisher;
    }

    public async Task<Result> Handle(UpdateWorkflowCommand request, CancellationToken cancellationToken)
    {
        var workflow = await _repository.GetByIdAndUserAsync(
            request.Id,
            request.OwnerId,
            includeGraph: false,
            cancellationToken);

        if (workflow is null)
        {
            return Result.Failure(WorkflowApplicationErrors.WorkflowNotFound);
        }

        workflow.Update(
            request.Name,
            request.Description,
            request.Graph.ToDomain(),
            request.Visual);

        _repository.Update(workflow);

        await _unitOfWork.CommitAsync(cancellationToken);

        var @event = new WorkflowUpdatedEvent(request.Id, request.OwnerId);
        await _publisher.Publish(@event, CancellationToken.None);

        return Result.Success();
    }
}