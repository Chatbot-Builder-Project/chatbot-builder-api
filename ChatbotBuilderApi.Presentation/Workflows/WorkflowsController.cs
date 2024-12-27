using Asp.Versioning;
using ChatbotBuilderApi.Application.Workflows.CreateWorkflow;
using ChatbotBuilderApi.Application.Workflows.DeleteWorkflow;
using ChatbotBuilderApi.Application.Workflows.GetWorkflow;
using ChatbotBuilderApi.Application.Workflows.ListWorkflows;
using ChatbotBuilderApi.Application.Workflows.UpdateWorkflow;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;
using ChatbotBuilderApi.Presentation.Core.Abstract;
using ChatbotBuilderApi.Presentation.Core.Extensions;
using ChatbotBuilderApi.Presentation.Core.Responses;
using ChatbotBuilderApi.Presentation.Graphs;
using ChatbotBuilderApi.Presentation.Workflows.QueryParams;
using ChatbotBuilderApi.Presentation.Workflows.Requests;
using ChatbotBuilderApi.Presentation.Workflows.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Workflows;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/workflows")]
[Authorize]
public sealed class WorkflowsController : AbstractController
{
    public WorkflowsController(ISender sender) : base(sender)
    {
    }

    /// <summary>
    /// Lists all workflows for the user based on the query parameters.
    /// </summary>
    /// <param name="queryParams"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet]
    [ProducesResponseType(typeof(WorkflowListViewModel), StatusCodes.Status200OK)]
    public async Task<ActionResult<WorkflowListViewModel>> ListWorkflows(
        [FromQuery] WorkflowListQueryParams queryParams,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var query = new ListWorkflowsQuery
        {
            OwnerId = new UserId(userId.Value),
            PageParams = queryParams.PageParams,
            Search = queryParams.Search
        };

        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Returns workflow details by id from the user's workflows.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(WorkflowViewModel), StatusCodes.Status200OK)]
    public async Task<ActionResult<WorkflowViewModel>> GetWorkflow(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var query = new GetWorkflowQuery
        {
            Id = new WorkflowId(id),
            OwnerId = new UserId(userId.Value)
        };

        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Creates a new workflow for the user.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<CreateResponse>> CreateWorkflow(
        [FromBody] CreateWorkflowRequest request,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new CreateWorkflowCommand
        {
            Name = request.Name,
            Description = request.Description,
            Graph = request.Graph.ToDto(),
            OwnerId = new UserId(userId.Value),
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? CreatedAtAction(
                nameof(GetWorkflow),
                new { id = result.Value.Id.Value },
                result.Value.ToResponse())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Updates a workflow for the user.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateWorkflow(
        [FromRoute] Guid id,
        [FromBody] UpdateWorkflowRequest request,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new UpdateWorkflowCommand
        {
            Id = new WorkflowId(id),
            OwnerId = new UserId(userId.Value),
            Name = request.Name,
            Description = request.Description,
            Graph = request.Graph.ToDto()
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Deletion of a workflow will delete all of its chatbots.
    /// Any conversation that uses a deleted chatbot will no longer be able to use it
    /// (further messages will return error response).
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteWorkflow(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new DeleteWorkflowCommand
        {
            Id = new WorkflowId(id),
            OwnerId = new UserId(userId.Value)
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : result.ToProblemDetails();
    }
}