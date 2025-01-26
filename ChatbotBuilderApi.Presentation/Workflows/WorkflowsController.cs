using Asp.Versioning;
using ChatbotBuilderApi.Application.Workflows.CreateWorkflow;
using ChatbotBuilderApi.Application.Workflows.DeleteWorkflow;
using ChatbotBuilderApi.Application.Workflows.GetWorkflow;
using ChatbotBuilderApi.Application.Workflows.ListWorkflows;
using ChatbotBuilderApi.Application.Workflows.UpdateWorkflow;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;
using ChatbotBuilderApi.Presentation.Core.Abstract;
using ChatbotBuilderApi.Presentation.Core.Attributes;
using ChatbotBuilderApi.Presentation.Core.Extensions;
using ChatbotBuilderApi.Presentation.Core.Responses;
using ChatbotBuilderApi.Presentation.Graphs;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
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
    /// <param name="queryParams">Query parameters for the list of workflows.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>A list of workflows.</returns>
    /// <response code="200">Returns the list of workflows for the user.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="422">If the request is invalid (validation error).</response>
    [HttpGet]
    [ProducesResponseType(typeof(WorkflowListViewModel), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
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
    /// <param name="id">ID of the workflow.</param>
    /// <param name="queryParams">Query parameters for the workflow.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>Details of the workflow.</returns>
    /// <response code="200">Returns the workflow details.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the workflow is not found in the user's workflows.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(WorkflowViewModel), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WorkflowViewModel>> GetWorkflow(
        [FromRoute] Guid id,
        [FromQuery] WorkflowQueryParams queryParams,
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
            OwnerId = new UserId(userId.Value),
            IncludeStats = queryParams.IncludeStats
        };

        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Creates a new workflow for the user.
    /// </summary>
    /// <param name="request">Request to create a new workflow.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>ID of the created workflow.</returns>
    /// <response code="201">Returns the ID of the created workflow.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="422">If the request is invalid (validation error).</response>
    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse), StatusCodes.Status201Created)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
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
            Visual = request.Visual.ToDomain()
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
    /// The new graph model will replace the existing one completely.
    /// So update workflows with caution as it's not cheap to create a new graph model.
    /// </summary>
    /// <param name="id">ID of the workflow.</param>
    /// <param name="request">Request to update the workflow.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>No content.</returns>
    /// <response code="204">No content.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the workflow is not found in the user's workflows.</response>
    /// <response code="422">If the request is invalid (validation error).</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
    [ProducesError(StatusCodes.Status422UnprocessableEntity)]
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
            Graph = request.Graph.ToDto(),
            Visual = request.Visual.ToDomain()
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Deletion of a workflow will delete all of its chatbots and consequently all of their conversations.
    /// So be very cautious with calling this endpoint.
    /// </summary>
    /// <param name="id">ID of the workflow.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>No content.</returns>
    /// <response code="204">No content.</response>
    /// <response code="401">Unauthorized if the user is not authenticated.</response>
    /// <response code="404">If the workflow is not found in the user's workflows.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesError(StatusCodes.Status401Unauthorized)]
    [ProducesError(StatusCodes.Status404NotFound)]
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