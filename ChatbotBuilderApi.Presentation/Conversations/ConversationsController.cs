using Asp.Versioning;
using ChatbotBuilderApi.Application.Conversations.DeleteConversation;
using ChatbotBuilderApi.Application.Conversations.GetConversation;
using ChatbotBuilderApi.Application.Conversations.ListConversations;
using ChatbotBuilderApi.Application.Conversations.StartConversation;
using ChatbotBuilderApi.Application.Conversations.UpdateConversation;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Presentation.Conversations.QueryParams;
using ChatbotBuilderApi.Presentation.Conversations.Requests;
using ChatbotBuilderApi.Presentation.Conversations.ViewModels;
using ChatbotBuilderApi.Presentation.Core.Abstract;
using ChatbotBuilderApi.Presentation.Core.Attributes;
using ChatbotBuilderApi.Presentation.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Conversations;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/conversations")]
[Authorize]
public sealed class ConversationsController : AbstractController
{
    public ConversationsController(ISender sender) : base(sender)
    {
    }

    /// <summary>
    /// Lists all conversations (history) for the user based on the query parameters.
    /// </summary>
    /// <param name="queryParams">Query parameters for the list of conversations.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>A list of conversations.</returns>
    /// <response code="200">Returns the list of conversations for the user.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="422">If the request is invalid (validation error).</response>
    [HttpGet]
    [ProducesResponseType(typeof(ConversationListViewModel), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<ConversationListViewModel>> ListConversations(
        [FromQuery] ConversationListQueryParams queryParams,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var query = new ListConversationsQuery
        {
            PageParams = queryParams.PageParams,
            UserId = new UserId(userId.Value),
            Search = queryParams.Search,
            ChatbotId = queryParams.ChatbotId is null
                ? null
                : new ChatbotId(queryParams.ChatbotId.Value)
        };

        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Returns a single conversation for the user by id based on the query parameters.
    /// Does not include the messages in the conversation.
    /// </summary>
    /// <param name="id">ID of the conversation.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>Conversation details.</returns>
    /// <response code="200">Returns the conversation for the user.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the conversation is not found in the user's conversations.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ConversationViewModel), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ConversationViewModel>> GetConversation(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var query = new GetConversationQuery
        {
            Id = new ConversationId(id),
            UserId = new UserId(userId.Value)
        };

        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Starts a new conversation for the current user.
    /// A new conversation will be created and a new copy of the chatbot's graph will be created
    /// which will be used solely for this conversation.
    /// </summary>
    /// <param name="request">Request to start a new conversation.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>ID of the created conversation with the initial message.</returns>
    /// <response code="201">Returns the ID of the created conversation with the initial message.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the chatbot is not found in the user's chatbots.</response>
    /// <response code="422">If the request is invalid (validation error).</response>
    [HttpPost]
    [ProducesResponseType(typeof(StartConversationViewModel), StatusCodes.Status201Created)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<StartConversationViewModel>> StartConversation(
        [FromBody] StartConversationRequest request,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new StartConversationCommand
        {
            ChatbotId = new ChatbotId(request.ChatbotId),
            UserId = new UserId(userId.Value),
            Name = request.Name
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? CreatedAtAction(
                nameof(GetConversation),
                new { id = result.Value.ConversationId },
                result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Updates the information of a conversation for the current user.
    /// To actually send a message to the conversation, use the SendMessage endpoint.
    /// </summary>
    /// <param name="id">ID of the conversation.</param>
    /// <param name="request">Request to update the conversation.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>No content.</returns>
    /// <response code="204">No content.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the conversation is not found in the user's conversations.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateConversation(
        [FromRoute] Guid id,
        [FromBody] UpdateConversationRequest request,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new UpdateConversationCommand
        {
            Id = new ConversationId(id),
            UserId = new UserId(userId.Value),
            Name = request.Name
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Deletes a conversation for the current user.
    /// </summary>
    /// <param name="id">ID of the conversation.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>No content.</returns>
    /// <response code="204">No content.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the conversation is not found in the user's conversations.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteConversation(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new DeleteConversationCommand
        {
            Id = new ConversationId(id),
            OwnerId = new UserId(userId.Value)
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : result.ToProblemDetails();
    }
}