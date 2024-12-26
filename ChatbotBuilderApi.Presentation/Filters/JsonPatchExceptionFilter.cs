using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Presentation.Shared.ResultExtensions;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChatbotBuilderApi.Presentation.Filters;

public class JsonPatchExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not JsonPatchException jsonPatchException)
        {
            return;
        }

        var error = Error.BadRequest(
            "JSON Patch Error",
            jsonPatchException.Message);

        context.Result = Result
            .Failure(error)
            .ToProblemDetails();

        context.ExceptionHandled = true;
    }
}