﻿using Microsoft.AspNetCore.Mvc;

namespace ChatbotBuilderApi.Presentation.Core.Attributes;

/// <summary>
/// Use this attribute when you want to document an Error Status Code.
/// It assumes that the object-result schema is <see cref="ProblemDetailsWithErrorsResponse"/>-like object.
/// </summary>
public class ProducesErrorAttribute : ProducesResponseTypeAttribute
{
    public ProducesErrorAttribute(int errorStatusCode)
        : base(typeof(ProblemDetailsWithErrorsResponse), errorStatusCode)
    {
        if (errorStatusCode < 400)
        {
            throw new InvalidOperationException($"{errorStatusCode} is not an error status code");
        }
    }
}

/// <summary>
/// Custom ProblemDetails object with Errors extension.
/// Defines error response type that controller endpoints typically produce.
/// </summary>
public sealed class ProblemDetailsWithErrorsResponse
{
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public List<ErrorResponse> Errors { get; set; } = [];

    public sealed class ErrorResponse
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}