using Asp.Versioning;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Images.DeleteImage;
using ChatbotBuilderApi.Application.Images.GetImage;
using ChatbotBuilderApi.Application.Images.ListImages;
using ChatbotBuilderApi.Application.Images.UpdateImage;
using ChatbotBuilderApi.Application.Images.UploadImage;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Presentation.Core.Abstract;
using ChatbotBuilderApi.Presentation.Core.Extensions;
using ChatbotBuilderApi.Presentation.Core.Responses;
using ChatbotBuilderApi.Presentation.Images.QueryParams;
using ChatbotBuilderApi.Presentation.Images.Requests;
using ChatbotBuilderApi.Presentation.Images.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Images;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/images")]
[Authorize]
public sealed class ImagesController : AbstractController
{
    public ImagesController(ISender sender) : base(sender)
    {
    }

    /// <summary>
    /// Gets the list of images for the user.
    /// </summary>
    /// <param name="queryParams"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(ImageListViewModel), StatusCodes.Status200OK)]
    public async Task<ActionResult<ImageListViewModel>> ListImages(
        [FromQuery] ImageListQueryParams queryParams,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var query = new ListImagesQuery
        {
            PageParams = queryParams.PageParams,
            OwnerId = new UserId(userId.Value),
            IncludeOnlyProfilePictures = queryParams.IncludeOnlyProfilePictures ?? false,
            Search = queryParams.Search
        };

        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Gets the image information for the user by the image id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ImageViewModel), StatusCodes.Status200OK)]
    public async Task<ActionResult<ImageViewModel>> GetImage(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var query = new GetImageQuery
        {
            ImageId = new ImageId(id),
            OwnerId = new UserId(userId.Value)
        };

        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value.ToViewModel())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Uploads an image for the user.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<CreateResponse>> UploadImage(
        [FromForm] UploadImageRequest request,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new UploadImageCommand
        {
            UserId = new UserId(userId.Value),
            FileUpload = new FileUpload(
                request.FileUpload.FileName,
                request.FileUpload.ContentType,
                request.FileUpload.OpenReadStream()),
            ImageMeta = ImageMeta.Create(request.IsProfilePicture ?? false)
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? CreatedAtAction(
                nameof(GetImage),
                new { id = result.Value.Id.Value },
                result.Value.ToResponse())
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Updates an image for the user.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateImage(
        [FromRoute] Guid id,
        [FromBody] UpdateImageRequest request,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new UpdateImageCommand
        {
            ImageId = new ImageId(id),
            OwnerId = new UserId(userId.Value),
            ImageMeta = ImageMeta.Create(request.IsProfilePicture)
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Deletes an image for the user.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteImage(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdOrFailure();
        if (userId.IsFailure)
        {
            return userId.ToProblemDetails();
        }

        var command = new DeleteImageCommand
        {
            ImageId = new ImageId(id),
            OwnerId = new UserId(userId.Value)
        };

        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : result.ToProblemDetails();
    }
}