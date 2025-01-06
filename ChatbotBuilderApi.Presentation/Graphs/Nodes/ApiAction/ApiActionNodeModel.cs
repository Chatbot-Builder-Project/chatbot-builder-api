using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Domain.Graphs.Nodes.ApiAction;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.ApiAction;

/// <summary>
/// API Action node model:
/// <list type="bullet">
/// <item>Executes an API call when activated.</item>
/// <item>The endpoint can be dynamic, constructed from an input port.</item>
/// <item>Requires details about the HTTP method, headers, and body.</item>
/// <item>Has an output port to pass along the API response.</item>
/// </list>
/// </summary>
/// <param name="Info">Generic information for the node.</param>
/// <param name="Visual">Visual information for the node.</param>
/// <param name="UrlInputPort">Text input port for the API endpoint URL.</param>
/// <param name="HttpMethod">The HTTP method to use (GET, POST, PUT, DELETE, etc.).</param>
/// <param name="Headers">Optional dictionary of headers to include in the API call.</param>
/// <param name="BodyInputPort">Optional input port for the request body.</param>
/// <param name="ResponseOutputPort">Output port for the API response. Must be of text data type.</param>
public sealed record ApiActionNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    InputPortModel UrlInputPort,
    ApiActionHttpMethod HttpMethod,
    IReadOnlyDictionary<string, string>? Headers,
    InputPortModel? BodyInputPort,
    OutputPortModel ResponseOutputPort)
    : NodeModel(Info, Visual, NodeType.ApiAction);