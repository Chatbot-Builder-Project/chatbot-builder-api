using System.Security.Claims;
using ChatbotBuilderApi.Application.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Core.Abstract;

public abstract class AbstractController : ControllerBase
{
    protected readonly ISender Sender;

    protected AbstractController(ISender sender) => Sender = sender;

    protected Result<Guid> GetUserIdOrFailure()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        return userIdClaim is null
            ? Result.Failure<Guid>(PresentationErrors.User.CredentialsNotProvided)
            : Result.Success(Guid.Parse(userIdClaim.Value));
    }
}