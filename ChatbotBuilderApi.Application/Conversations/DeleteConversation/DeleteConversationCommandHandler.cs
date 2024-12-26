using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Conversations.DeleteConversation;

public sealed class DeleteConversationCommandHandler : ICommandHandler<DeleteConversationCommand>
{
    private readonly IConversationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteConversationCommandHandler(
        IConversationRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
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

        return Result.Success();
    }
}