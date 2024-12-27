using Asp.Versioning;
using ChatbotBuilderApi.Presentation.Core.Abstract;
using ChatbotBuilderApi.Presentation.Shared.Responses;
using ChatbotBuilderApi.Presentation.Workflows.QueryParams;
using ChatbotBuilderApi.Presentation.Workflows.Requests;
using ChatbotBuilderApi.Presentation.Workflows.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Workflows;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/workflows")]
[Authorize]
public class WorkflowsController : AbstractController
{
    /// <summary>
    /// Lists all workflows for the user based on the query parameters.
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet]
    [ProducesResponseType(typeof(WorkflowListViewModel), StatusCodes.Status200OK)]
    public Task<ActionResult<WorkflowListViewModel>> ListWorkflows(
        [FromQuery] WorkflowListQueryParams queryParams)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns workflow details by id from the user's workflows.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(WorkflowDetailsViewModel), StatusCodes.Status200OK)]
    public Task<ActionResult<WorkflowDetailsViewModel>> GetWorkflow(
        [FromRoute] Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a new workflow for the user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost]
    [ProducesResponseType(typeof(CreatedResponse), StatusCodes.Status201Created)]
    public Task<ActionResult<CreatedResponse>> CreateWorkflow(
        [FromBody] CreateWorkflowRequest request)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a workflow for the user.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public Task<IActionResult> UpdateWorkflow(
        [FromRoute] Guid id,
        [FromBody] UpdateWorkflowRequest request)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletion of a workflow will delete all of its chatbots.
    /// Any conversation that uses a deleted chatbot will no longer be able to use it
    /// (further messages will return error response).
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public Task<IActionResult> DeleteWorkflow(
        [FromRoute] Guid id)
    {
        throw new NotImplementedException();
    }
}