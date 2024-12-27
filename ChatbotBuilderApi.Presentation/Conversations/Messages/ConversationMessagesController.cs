using Asp.Versioning;
using ChatbotBuilderApi.Application.Conversations.ListMessages;
using ChatbotBuilderApi.Application.Conversations.SendMessage;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Presentation.Conversations.Messages.QueryParams;
using ChatbotBuilderApi.Presentation.Conversations.Messages.Requests;
using ChatbotBuilderApi.Presentation.Conversations.Messages.ViewModels;
using ChatbotBuilderApi.Presentation.Core.Abstract;
using ChatbotBuilderApi.Presentation.Core.Extensions;
using ChatbotBuilderApi.Presentation.Graphs.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Conversations.Messages;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/conversations/{conversationId:guid}/messages")]
[Authorize]
public sealed class ConversationMessagesController : AbstractController
{
    public ConversationMessagesController(ISender sender) : base(sender)
    {
    }

    /// <summary>
    /// Lists conversation messages for the user based on the query parameters.
    /// </summary>
    /// <param name="conversationId"></param>
    /// <param name="queryParams"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet]
    [ProducesResponseType(typeof(MessageListViewModel), StatusCodes.Status200OK)]
    public async Task<ActionResult<MessageListViewModel>> ListMessages(
        [FromRoute] Guid conversationId,
        [FromQuery] MessageListQueryParams queryParams,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var query = new ListMessagesQuery
        {
            ConversationId = new ConversationId(conversationId),
            PageParams = queryParams.PageParams,
            UserId = new UserId(userId.Value)
        };

        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Sends a message to a conversation and receives the response immediately.
    /// </summary>
    /// <param name="conversationId"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost]
    [ProducesResponseType(typeof(SendMessageViewModel), StatusCodes.Status200OK)]
    public async Task<ActionResult<SendMessageViewModel>> SendMessage(
        [FromRoute] Guid conversationId,
        [FromBody] SendMessageRequest request,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new SendMessageCommand
        {
            ConversationId = new ConversationId(conversationId),
            UserId = new UserId(userId.Value),
            InputMessage = InputMessage.Create(InteractionInput.Create(
                request.Text?.ToDomain(),
                request.Option?.ToDomain()
            ))
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }
}