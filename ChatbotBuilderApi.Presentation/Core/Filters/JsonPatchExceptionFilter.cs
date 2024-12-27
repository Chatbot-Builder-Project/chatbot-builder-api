using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Presentation.Core.Extensions;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChatbotBuilderApi.Presentation.Core.Filters;

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