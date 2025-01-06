namespace ChatbotBuilderApi.Domain.Graphs.Abstract.Services;

public interface IApiActionService
{
    /// <summary>
    /// Executes an API call.
    /// </summary>
    /// <param name="url">The API endpoint URL.</param>
    /// <param name="method">The HTTP method to use.</param>
    /// <param name="headers">Optional headers for the request.</param>
    /// <param name="body">Optional body content for the request.</param>
    /// <returns>The response as a string.</returns>
    Task<string> ExecuteApiCallAsync(
        string url,
        ApiActionHttpMethod method,
        IReadOnlyDictionary<string, string>? headers,
        string? body);
}

public enum ApiActionHttpMethod
{
    Get,
    Post,
    Put,
    Delete,
    Patch,
    Head,
    Options
}