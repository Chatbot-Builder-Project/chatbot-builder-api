using ChatbotBuilderApi.Domain.Core.Primitives;
using Newtonsoft.Json.Linq;

namespace ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

public sealed class VisualMeta : ValueObject
{
    public JObject? Data { get; init; }

    private VisualMeta(JObject? data) => Data = data;

    /// <inheritdoc/>
    private VisualMeta()
    {
    }

    public static VisualMeta Create(JObject? data) => new(data);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return (object?)Data ?? false;
    }
}