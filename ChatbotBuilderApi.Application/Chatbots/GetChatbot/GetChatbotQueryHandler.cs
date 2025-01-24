using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Application.Chatbots.GetChatbot;

public sealed class GetChatbotQueryHandler : IQueryHandler<GetChatbotQuery, GetChatbotResponse>
{
    private readonly IChatbotRepository _repository;

    public GetChatbotQueryHandler(IChatbotRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetChatbotResponse>> Handle(GetChatbotQuery request, CancellationToken cancellationToken)
    {
        var chatbot = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (chatbot is null)
        {
            return Result.Failure<GetChatbotResponse>(ChatbotApplicationErrors.ChatbotNotFound);
        }

        var ownerId = (await _repository.GetOwnerIdAsync(request.Id, cancellationToken))!;

        GetChatbotResponseAdminDetails? adminDetails = null;
        if (request.UserId == ownerId)
        {
            var latestVersion = await _repository.GetLatestVersionAsync(
                chatbot.WorkflowId,
                chatbot.IsPublic,
                cancellationToken);

            adminDetails = new GetChatbotResponseAdminDetails(
                chatbot.Version,
                chatbot.WorkflowId,
                chatbot.IsPublic,
                chatbot.Version == latestVersion);
        }

        var response = new GetChatbotResponse(
            chatbot.Id,
            ownerId,
            chatbot.CreatedAt,
            chatbot.UpdatedAt,
            chatbot.Name,
            chatbot.Description,
            chatbot.AvatarImageData,
            adminDetails);

        return Result.Success(response);
    }
}