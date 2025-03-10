using ChatbotBuilderApi.Application.Core.Abstract;
using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Chatbots.UpdateChatbot;

public sealed class UpdateChatbotCommandHandler : ICommandHandler<UpdateChatbotCommand>
{
    private readonly IChatbotRepository _chatbotRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateChatbotCommandHandler(
        IChatbotRepository chatbotRepository,
        IUnitOfWork unitOfWork)
    {
        _chatbotRepository = chatbotRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateChatbotCommand request, CancellationToken cancellationToken)
    {
        var chatbot = await _chatbotRepository.GetByIdAndOwnerAsync(request.Id, request.OwnerId, cancellationToken);
        if (chatbot is null)
        {
            return Result.Failure(ChatbotApplicationErrors.ChatbotNotFound);
        }

        chatbot.Update(
            request.Name,
            request.Description,
            request.IsPublic,
            request.AvatarImageData,
            request.Visual);
        _chatbotRepository.Update(chatbot);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}