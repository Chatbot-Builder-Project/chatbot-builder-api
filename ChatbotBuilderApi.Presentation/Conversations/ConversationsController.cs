using Asp.Versioning;
using ChatbotBuilderApi.Application.Conversations.DeleteConversation;
using ChatbotBuilderApi.Application.Conversations.GetConversation;
using ChatbotBuilderApi.Application.Conversations.ListConversations;
using ChatbotBuilderApi.Application.Conversations.StartConversation;
using ChatbotBuilderApi.Application.Conversations.UpdateConversation;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;
using ChatbotBuilderApi.Presentation.Conversations.QueryParams;
using ChatbotBuilderApi.Presentation.Conversations.Requests;
using ChatbotBuilderApi.Presentation.Conversations.ViewModels;
using ChatbotBuilderApi.Presentation.Core.Abstract;
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
    /// <param name="queryParams"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(ConversationListViewModel), StatusCodes.Status200OK)]
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
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ConversationViewModel), StatusCodes.Status200OK)]
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
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(StartConversationViewModel), StatusCodes.Status201Created)]
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
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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