using Asp.Versioning;
using ChatbotBuilderApi.Presentation.Chatbots.QueryParams;
using ChatbotBuilderApi.Presentation.Chatbots.Requests;
using ChatbotBuilderApi.Presentation.Chatbots.ViewModels;
using ChatbotBuilderApi.Presentation.Core.Abstract;
using ChatbotBuilderApi.Presentation.Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Chatbots;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/chatbots")]
[Authorize]
public class ChatbotsController : AbstractController
{
    /// <summary>
    /// Lists all chatbots in the system based on the query parameters.
    /// For the user's chatbots, both public and private chatbots are returned.
    /// For other users' chatbots, only public chatbots are returned.
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet]
    [ProducesResponseType(typeof(ChatbotListViewModel), StatusCodes.Status200OK)]
    public Task<ActionResult<ChatbotListViewModel>> ListChatbots(
        [FromQuery] ChatbotListQueryParams queryParams)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a single chatbot by id.
    /// AdminDetails will be included in the response if and only if the chatbot is owned by the user.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ChatbotViewModel), StatusCodes.Status200OK)]
    public Task<ActionResult<ChatbotViewModel>> GetChatbot(
        [FromRoute] Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a new chatbot from a given workflow.
    /// A chatbot is a workflow with a fixed version that users can interact with.
    /// When a workflow is published, a copy of the workflow is created as a chatbot with a new version.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost]
    [ProducesResponseType(typeof(CreatedResponse), StatusCodes.Status201Created)]
    public Task<ActionResult<CreatedResponse>> CreateChatbot(
        [FromBody] CreateChatbotRequest request)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the information of a chatbot owned by the user.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public Task<IActionResult> UpdateChatbot(
        [FromRoute] Guid id,
        [FromBody] UpdateChatbotRequest request)
    {
        throw new NotImplementedException();
    }
}