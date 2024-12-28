using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using MediatR;

namespace ChatbotBuilderApi.Application.Conversations.DeleteConversation;

public sealed class DeleteConversationCommandHandler : ICommandHandler<DeleteConversationCommand>
{
    private readonly IConversationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _publisher;

    public DeleteConversationCommandHandler(
        IConversationRepository repository,
        IUnitOfWork unitOfWork,
        IPublisher publisher)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _publisher = publisher;
    }

    public async Task<Result> Handle(DeleteConversationCommand request, CancellationToken cancellationToken)
    {
        var conversation = await _repository.GetByIdAndUserAsync(
            request.Id,
            request.OwnerId,
            cancellationToken);

        if (conversation is null)
        {
            return Result.Failure(ConversationsApplicationErrors.ConversationNotFound);
        }

        _repository.Delete(conversation);
        await _unitOfWork.CommitAsync(cancellationToken);

        var @event = new ConversationDeletedEvent(request.Id, request.OwnerId);
        await _publisher.Publish(@event, CancellationToken.None);

        return Result.Success();
    }
}