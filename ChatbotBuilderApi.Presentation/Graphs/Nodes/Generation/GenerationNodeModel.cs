using ChatbotBuilderApi.Application.Graphs.Nodes;
using ChatbotBuilderApi.Presentation.Graphs.Metas;
using ChatbotBuilderApi.Presentation.Graphs.Ports;
using Newtonsoft.Json.Linq;

namespace ChatbotBuilderApi.Presentation.Graphs.Nodes.Generation;

/// <summary>
/// Generation node model.
/// This node makes an LLM based on the input and the options and returns a response.
/// </summary>
/// <param name="Info">Generic information for the node.</param>
/// <param name="Visual">Visual information for the node.</param>
/// <param name="InputPort">Input port of the node. Must be of Text data type.</param>
/// <param name="OutputPort">Output port of the node. Must be of Text data type.</param>
/// <param name="Options">Options for the generation.</param>
public sealed record GenerationNodeModel(
    InfoMetaModel Info,
    VisualMetaModel Visual,
    InputPortModel InputPort,
    OutputPortModel OutputPort,
    GenerationOptionsModel Options)
    : NodeModel(Info, Visual, NodeType.Generation);

/// <summary>
/// Options for the generation.
/// </summary>
/// <param name="UseMemory">Whether the node take into account previous interactions (has internal memory).</param>
/// <param name="ResponseSchema">Whether the output should conform to a specific schema.
/// The LLM will be asked to generate based on this schema and its output will be repeatidly validated.</param>
public sealed record GenerationOptionsModel(
    bool UseMemory,
    JObject ResponseSchema);