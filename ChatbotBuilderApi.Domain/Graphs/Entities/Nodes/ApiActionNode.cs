using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderApi.Domain.Graphs.Abstract.Services;
using ChatbotBuilderApi.Domain.Graphs.Entities.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs.Entities.Nodes;

public sealed class ApiActionNode : Node,
    IInputNode, IOutputNode
{
    public InputPort<TextData> UrlInputPort { get; } = null!;
    public ApiActionHttpMethod HttpMethod { get; }
    public IReadOnlyDictionary<string, string>? Headers { get; }
    public InputPort<TextData>? BodyInputPort { get; }
    public OutputPort<TextData> ResponseOutputPort { get; } = null!;

    public string ActionResponse { get; private set; } = string.Empty;

    public ApiActionNode(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<TextData> urlInputPort,
        ApiActionHttpMethod httpMethod,
        IReadOnlyDictionary<string, string>? headers,
        InputPort<TextData>? bodyInputPort,
        OutputPort<TextData> responseOutputPort)
        : base(id, info, visual)
    {
        UrlInputPort = urlInputPort;
        HttpMethod = httpMethod;
        Headers = headers;
        BodyInputPort = bodyInputPort;
        ResponseOutputPort = responseOutputPort;
    }

    /// <inheritdoc/>
    private ApiActionNode()
    {
    }

    public static ApiActionNode Create(
        NodeId id,
        InfoMeta info,
        VisualMeta visual,
        InputPort<TextData> urlInputPort,
        ApiActionHttpMethod httpMethod,
        IReadOnlyDictionary<string, string>? headers,
        InputPort<TextData>? bodyInputPort,
        OutputPort<TextData> responseOutputPort)
    {
        return new ApiActionNode(
            id,
            info,
            visual,
            urlInputPort,
            httpMethod,
            headers,
            bodyInputPort,
            responseOutputPort);
    }

    public override async Task RunAsync(NodeExecutionContext context)
    {
        var url = UrlInputPort.GetData().Text;
        var body = BodyInputPort?.GetData().Text;

        ActionResponse = await context.ApiActionService.ExecuteApiCallAsync(url, HttpMethod, Headers, body);
    }

    public IEnumerable<Port<InputPortId>> GetInputPorts()
    {
        yield return UrlInputPort;

        if (BodyInputPort is not null)
        {
            yield return BodyInputPort;
        }
    }

    public IEnumerable<Port<OutputPortId>> GetOutputPorts()
    {
        yield return ResponseOutputPort;
    }

    public void PublishOutputs()
    {
        ResponseOutputPort.Publish(TextData.Create(ActionResponse));
    }
}