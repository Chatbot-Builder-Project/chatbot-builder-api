using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using MediatR;

namespace ChatbotBuilderApi.Application.Workflows.DeleteWorkflow;

public sealed class DeleteWorkflowCommandHandler : ICommandHandler<DeleteWorkflowCommand>
{
    private readonly IWorkflowRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _publisher;

    public DeleteWorkflowCommandHandler(
        IWorkflowRepository repository,
        IUnitOfWork unitOfWork,
        IPublisher publisher)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _publisher = publisher;
    }

    public async Task<Result> Handle(DeleteWorkflowCommand request, CancellationToken cancellationToken)
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

        _repository.Delete(workflow);
        await _unitOfWork.CommitAsync(cancellationToken);

        var @event = new WorkflowDeletedEvent(request.Id, request.OwnerId);
        await _publisher.Publish(@event, CancellationToken.None);

        return Result.Success();
    }
}