using ChatbotBuilderApi.Domain.Core.Primitives;
using Newtonsoft.Json.Linq;

namespace ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;

public sealed class GenerationOptions : ValueObject
{
    public bool UseMemory { get; }
    public JObject? ResponseSchema { get; }

    private GenerationOptions(
        bool useMemory,
        JObject? responseSchema)
    {
        UseMemory = useMemory;
        ResponseSchema = responseSchema;
    }

    /// <inheritdoc/>
    private GenerationOptions()
    {
    }

    public static GenerationOptions Create(bool useMemory, JObject? responseSchema) => new(useMemory, responseSchema);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return UseMemory;
    }
}