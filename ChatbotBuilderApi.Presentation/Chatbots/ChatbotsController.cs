using Asp.Versioning;
using ChatbotBuilderApi.Application.Chatbots.CreateChatbot;
using ChatbotBuilderApi.Application.Chatbots.DeleteChatbot;
using ChatbotBuilderApi.Application.Chatbots.GetChatbot;
using ChatbotBuilderApi.Application.Chatbots.ListChatbots;
using ChatbotBuilderApi.Application.Chatbots.UpdateChatbot;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;
using ChatbotBuilderApi.Presentation.Chatbots.QueryParams;
using ChatbotBuilderApi.Presentation.Chatbots.Requests;
using ChatbotBuilderApi.Presentation.Chatbots.ViewModels;
using ChatbotBuilderApi.Presentation.Core.Abstract;
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
    /// <param name="queryParams"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(ChatbotListViewModel), StatusCodes.Status200OK)]
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
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ChatbotViewModel), StatusCodes.Status200OK)]
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
    /// Creates a new chatbot from a given workflow.
    /// A chatbot is a workflow with a fixed version that users can interact with.
    /// When a workflow is published, a copy of the workflow is created as a chatbot with a new version.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse), StatusCodes.Status201Created)]
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
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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
            IsPublic = request.IsPublic
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Deletes a chatbot owned by the user.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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