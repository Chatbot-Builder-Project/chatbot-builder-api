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
using ChatbotBuilderApi.Presentation.Core.Attributes;
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
    /// A single PageParameters controls the pagination of both input and output messages.
    /// </summary>
    /// <param name="conversationId">ID of the conversation.</param>
    /// <param name="queryParams">Query parameters for the message list.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>List of messages in the conversation.</returns>
    /// <response code="200">Returns the list of messages for the conversation.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the conversation is not found in the user's conversations.</response>
    /// <response code="422">If the request is invalid (validation error).</response>
    [HttpGet]
    [ProducesResponseType(typeof(MessageListViewModel), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
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
    /// Sends a message to a conversation and retrieves the system response immediately.
    /// </summary>
    /// <param name="conversationId">ID of the conversation.</param>
    /// <param name="request">Request to send a message.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>System response to the message.</returns>
    /// <response code="200">Returns the system response to the message.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the conversation is not found in the user's conversations.</response>
    /// <response code="422">If the request is invalid (validation error).</response>
    [HttpPost]
    [ProducesResponseType(typeof(SendMessageViewModel), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
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