namespace ChatbotBuilderApi.Presentation.Core.Extensions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public static class IdentityResultExtensions
{
    public static ObjectResult ToProblemDetails(this IdentityResult identityResult)
    {
        if (identityResult.Succeeded)
        {
            throw new InvalidOperationException("Cannot create problem details for a successful IdentityResult.");
        }

        var statusCode = DetermineStatusCode(identityResult);

        return new ObjectResult(CreateProblemDetails(identityResult, statusCode))
        {
            StatusCode = statusCode
        };
    }

    private static int DetermineStatusCode(IdentityResult identityResult)
    {
        if (identityResult.Errors.Any(e => e.Code.Equals("DuplicateEmail", StringComparison.OrdinalIgnoreCase)))
        {
            return StatusCodes.Status409Conflict;
        }

        if (identityResult.Errors.Any(e => e.Code.Equals("PasswordTooWeak", StringComparison.OrdinalIgnoreCase)))
        {
            return StatusCodes.Status400BadRequest;
        }

        if (identityResult.Errors.Any(e => e.Code.Equals("UserNotFound", StringComparison.OrdinalIgnoreCase)))
        {
            return StatusCodes.Status404NotFound;
        }

        // Default to 400 Bad Request for general validation errors
        return StatusCodes.Status400BadRequest;
    }

    private static ProblemDetails CreateProblemDetails(IdentityResult identityResult, int statusCode)
    {
        return new ProblemDetails
        {
            Status = statusCode,
            Title = GetTitleForStatusCode(statusCode),
            Type = GetTypeForStatusCode(statusCode),
            Extensions =
            {
                ["errors"] = identityResult.Errors.Select(e => new
                {
                    code = e.Code,
                    message = e.Description
                }).ToArray()
            }
        };
    }

    private static string GetTitleForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            StatusCodes.Status400BadRequest => "Bad Request",
            StatusCodes.Status404NotFound => "Not Found",
            StatusCodes.Status409Conflict => "Conflict",
            _ => "Validation Error"
        };
    }

    private static string GetTypeForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            StatusCodes.Status400BadRequest => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            StatusCodes.Status404NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            StatusCodes.Status409Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            _ => "https://tools.ietf.org/html/rfc7231#section-6.5"
        };
    }
}