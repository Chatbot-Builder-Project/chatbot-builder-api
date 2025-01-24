using Asp.Versioning;
using ChatbotBuilderApi.Application.Chatbots.CreateChatbot;
using ChatbotBuilderApi.Application.Chatbots.DeleteChatbot;
using ChatbotBuilderApi.Application.Chatbots.GetChatbot;
using ChatbotBuilderApi.Application.Chatbots.ListChatbots;
using ChatbotBuilderApi.Application.Chatbots.UpdateChatbot;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;
using ChatbotBuilderApi.Presentation.Chatbots.QueryParams;
using ChatbotBuilderApi.Presentation.Chatbots.Requests;
using ChatbotBuilderApi.Presentation.Chatbots.ViewModels;
using ChatbotBuilderApi.Presentation.Core.Abstract;
using ChatbotBuilderApi.Presentation.Core.Attributes;
using ChatbotBuilderApi.Presentation.Core.Extensions;
using ChatbotBuilderApi.Presentation.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Chatbots;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/chatbots")]
[Authorize]
public sealed class ChatbotsController : AbstractController
{
    public ChatbotsController(ISender sender) : base(sender)
    {
    }

    /// <summary>
    /// Lists all chatbots in the system based on the query parameters.
    /// For the user's chatbots, both public and private chatbots are returned.
    /// For other users' chatbots, only public chatbots are returned.
    /// </summary>
    /// <param name="queryParams">Query parameters for the list of chatbots.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>A list of chatbots.</returns>
    /// <response code="200">Returns the list of chatbots for the user.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="422">If the request is invalid (validation error).</response>
    [HttpGet]
    [ProducesResponseType(typeof(ChatbotListViewModel), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<ChatbotListViewModel>> ListChatbots(
        [FromQuery] ChatbotListQueryParams queryParams,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var query = new ListChatbotsQuery
        {
            PageParams = queryParams.PageParams,
            UserId = new UserId(userId.Value),
            Search = queryParams.Search,
            IncludeOnlyLatest = queryParams.IncludeOnlyLatest,
            IncludeOnlyPersonal = queryParams.IncludeOnlyPersonal,
            WorkflowId = queryParams.WorkflowId != null
                ? new WorkflowId(queryParams.WorkflowId.Value)
                : null
        };

        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Returns a single chatbot by id.
    /// AdminDetails will be included in the response if and only if the chatbot is owned by the user.
    /// </summary>
    /// <param name="id">ID of the chatbot.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>Details of the chatbot.</returns>
    /// <response code="200">Returns the chatbot details.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the chatbot is not found in the user's chatbots.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ChatbotViewModel), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ChatbotViewModel>> GetChatbot(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var query = new GetChatbotQuery
        {
            Id = new ChatbotId(id),
            UserId = new UserId(userId.Value)
        };

        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Creates a new chatbot from a given workflow with the same name and description of the workflow.
    /// A chatbot is a copy of the workflow with a new version and a fixed graph.
    /// </summary>
    /// <param name="request">Request to create a chatbot.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>ID of the created chatbot.</returns>
    /// <response code="201">Returns the ID of the created chatbot.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the workflow is not found.</response>
    /// <response code="422">If the request is invalid (validation error).</response>
    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse), StatusCodes.Status201Created)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<CreateResponse>> CreateChatbot(
        [FromBody] CreateChatbotRequest request,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new CreateChatbotCommand
        {
            WorkflowId = new WorkflowId(request.WorkflowId),
            OwnerId = new UserId(userId.Value),
            IsPublic = request.IsPublic
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? CreatedAtAction(
                nameof(GetChatbot),
                new { id = result.Value.Id.Value },
                result.Value.ToResponse())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Updates the information of a chatbot owned by the user.
    /// </summary>
    /// <param name="id">ID of the chatbot.</param>
    /// <param name="request">Request to update the chatbot.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>No content.</returns>
    /// <response code="204">No content.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the chatbot is not found in the user's chatbots.</response>
    /// <response code="422">If the request is invalid (validation error).</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateChatbot(
        [FromRoute] Guid id,
        [FromBody] UpdateChatbotRequest request,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new UpdateChatbotCommand
        {
            Id = new ChatbotId(id),
            OwnerId = new UserId(userId.Value),
            Name = request.Name,
            Description = request.Description,
            IsPublic = request.IsPublic,
            AvatarImageData = request.AvatarImage is null
                ? null
                : ImageData.Create(request.AvatarImage.Url)
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Deletion of a chatbot will delete all of its conversations.
    /// So be very cautious with calling this endpoint.
    /// </summary>
    /// <param name="id">ID of the chatbot.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>No content.</returns>
    /// <response code="204">No content.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the chatbot is not found in the user's chatbots.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteChatbot(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new DeleteChatbotCommand
        {
            Id = new ChatbotId(id),
            OwnerId = new UserId(userId.Value)
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : result.ToProblemDetails();
    }
}