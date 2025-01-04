using Asp.Versioning;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Users;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Presentation.Core.Abstract;
using ChatbotBuilderApi.Presentation.Core.Attributes;
using ChatbotBuilderApi.Presentation.Core.Extensions;
using ChatbotBuilderApi.Presentation.Core.Responses;
using ChatbotBuilderApi.Presentation.Users.Requests;
using ChatbotBuilderApi.Presentation.Users.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Users;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/users")]
[Authorize]
public sealed class UsersController : AbstractController
{
    private readonly UserManager<User> _userManager;

    public UsersController(ISender sender, UserManager<User> userManager) : base(sender)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Gets a user by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserViewModel>> GetUserById(
        [FromRoute] Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return Result
                .Failure(UsersApplicationErrors.UserNotFound)
                .ToProblemDetails();
        }

        return Ok(new UserViewModel(
            user.Id,
            user.UserName!,
            user.Email!,
            user.FirstName,
            user.LastName
        ));
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="userRequest"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CreateResponse), StatusCodes.Status201Created)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateResponse>> RegisterUser(
        [FromBody] RegisterUserRequest userRequest)
    {
        var user = new User
        {
            UserName = userRequest.UserName,
            Email = userRequest.Email,
            FirstName = userRequest.FirstName,
            LastName = userRequest.LastName
        };

        var result = await _userManager.CreateAsync(user, userRequest.Password);
        return result.Succeeded
            ? CreatedAtAction(
                nameof(GetUserById),
                new { id = user.Id },
                new CreateResponse(user.Id))
            : result.ToProblemDetails();
    }

    /// <summary>
    /// Gets the currently logged-in user.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserViewModel>> GetCurrentUser()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Result
                .Failure(UsersApplicationErrors.UserNotFound)
                .ToProblemDetails();
        }

        return Ok(new UserViewModel(
            user.Id,
            user.UserName!,
            user.Email!,
            user.FirstName,
            user.LastName
        ));
    }

    /// <summary>
    /// Updates the currently logged-in user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    [ProducesError(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCurrentUser(
        [FromBody] UpdateUserRequest request)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Result
                .Failure(UsersApplicationErrors.UserNotFound)
                .ToProblemDetails();
        }

        if (!string.IsNullOrEmpty(request.FirstName))
        {
            user.FirstName = request.FirstName;
        }

        if (!string.IsNullOrEmpty(request.LastName))
        {
            user.LastName = request.LastName;
        }

        if (!string.IsNullOrEmpty(request.NewEmail))
        {
            var setEmailResult = await _userManager.SetEmailAsync(user, request.NewEmail);
            if (!setEmailResult.Succeeded)
            {
                return setEmailResult.ToProblemDetails();
            }
        }

        if (!string.IsNullOrEmpty(request.NewPassword))
        {
            if (string.IsNullOrEmpty(request.OldPassword))
            {
                return Result
                    .Failure(UsersApplicationErrors.OldPasswordRequired)
                    .ToProblemDetails();
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(
                user,
                request.OldPassword,
                request.NewPassword);

            if (!changePasswordResult.Succeeded)
            {
                return changePasswordResult.ToProblemDetails();
            }
        }

        var updateResult = await _userManager.UpdateAsync(user);
        return updateResult.Succeeded
            ? Ok(new { Message = "User information updated successfully." })
            : updateResult.ToProblemDetails();
    }
}