using ChatbotBuilderApi.Domain.Shared;
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

        var error = new Error(
            ErrorType.BadRequest,
            "JSON Patch Error",
            jsonPatchException.Message);

        context.Result = Result
            .Failure(error)
            .ToProblemDetails();

        context.ExceptionHandled = true;
    }
}