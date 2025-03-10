﻿using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Core.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Core.Extensions;

public static class ResultExtensions
{
    public static ObjectResult ToProblemDetails(this Result result)
    {
        return result.Error.Type switch
        {
            ErrorType.DomainInvariant => result.ToBadRequestProblemDetails(),
            ErrorType.ApplicationValidation => result.ToBadRequestProblemDetails(),
            ErrorType.BadRequest => result.ToBadRequestProblemDetails(),
            ErrorType.NotFound => result.ToNotFoundProblemDetails(),
            ErrorType.NotAuthorized => result.ToUnauthorizedProblemDetails(),
            ErrorType.Conflict => result.ToConflictProblemDetails(),
            ErrorType.InternalServerError => result.ToInternalServerErrorProblemDetails(),
            ErrorType.Forbidden => result.ToForbiddenProblemDetails(),
            ErrorType.TooManyRequests => result.ToTooManyRequestsProblemDetails(),
            ErrorType.None => throw new InvalidOperationException(
                $"Cannot create problem details for the successful result '{result}'"),
            _ => throw new ArgumentOutOfRangeException(nameof(result.Error.Type) + " undefined type")
        };
    }

    private static BadRequestObjectResult ToBadRequestProblemDetails(this Result result)
    {
        return new BadRequestObjectResult(CreateProblemDetails(
            result,
            StatusCodes.Status400BadRequest,
            "Bad Request",
            "https://tools.ietf.org/html/rfc7231#section-6.5.1"));
    }

    private static NotFoundObjectResult ToNotFoundProblemDetails(this Result result)
    {
        return new NotFoundObjectResult(CreateProblemDetails(
            result,
            StatusCodes.Status404NotFound,
            "Not Found",
            "https://tools.ietf.org/html/rfc7231#section-6.5.4"));
    }

    private static UnauthorizedObjectResult ToUnauthorizedProblemDetails(this Result result)
    {
        return new UnauthorizedObjectResult(CreateProblemDetails(
            result,
            StatusCodes.Status401Unauthorized,
            "Unauthorized",
            "https://tools.ietf.org/html/rfc7235#section-3.1"));
    }

    private static ConflictObjectResult ToConflictProblemDetails(this Result result)
    {
        return new ConflictObjectResult(CreateProblemDetails(
            result,
            StatusCodes.Status409Conflict,
            "Conflict",
            "https://tools.ietf.org/html/rfc7231#section-6.5.8"));
    }

    private static ObjectResult ToInternalServerErrorProblemDetails(this Result result)
    {
        return new ObjectResult(CreateProblemDetails(
            result,
            StatusCodes.Status500InternalServerError,
            "Internal Server Error",
            "https://tools.ietf.org/html/rfc7231#section-6.6.1"))
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }

    private static ObjectResult ToForbiddenProblemDetails(this Result result)
    {
        return new ObjectResult(CreateProblemDetails(
            result,
            StatusCodes.Status403Forbidden,
            "Forbidden",
            "https://tools.ietf.org/html/rfc7231#section-6.5.3"))
        {
            StatusCode = StatusCodes.Status403Forbidden
        };
    }

    private static ObjectResult ToTooManyRequestsProblemDetails(this Result result)
    {
        return new ObjectResult(CreateProblemDetails(
            result,
            StatusCodes.Status429TooManyRequests,
            "Too Many Requests",
            "https://tools.ietf.org/html/rfc6585#section-4"))
        {
            StatusCode = StatusCodes.Status429TooManyRequests
        };
    }

    private static ProblemDetails CreateProblemDetails(
        Result result,
        int statusCode,
        string title,
        string type)
    {
        return new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Extensions =
            {
                ["errors"] = new[]
                {
                    new
                    {
                        code = result.Error.Code,
                        message = result.Error.Message
                    }
                }
            }
        };
    }
}