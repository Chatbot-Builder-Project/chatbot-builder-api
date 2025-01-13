using System.Text;
using ChatbotBuilderApi.Domain.Graphs.Nodes.ApiAction;

namespace ChatbotBuilderApi.Infrastructure.GraphServices;

/// <summary>
/// Service for executing API calls.
/// Returns the response as a string weather the call was successful or not.
/// Does not throw exceptions.
/// </summary>
public sealed class ApiActionService : IApiActionService
{
    private readonly HttpClient _httpClient;

    public ApiActionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> ExecuteApiCallAsync(
        string url,
        ApiActionHttpMethod method,
        IReadOnlyDictionary<string, string>? headers,
        string? body)
    {
        using var request = new HttpRequestMessage(new HttpMethod(method.ToString()), url);

        if (headers is not null)
        {
            foreach (var (key, value) in headers)
            {
                request.Headers.TryAddWithoutValidation(key, value);
            }
        }

        if (!string.IsNullOrEmpty(body))
        {
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");
        }

        try
        {
            using var response = await _httpClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}