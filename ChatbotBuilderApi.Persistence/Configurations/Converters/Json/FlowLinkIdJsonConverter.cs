using System.Text.Json;
using System.Text.Json.Serialization;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderApi.Persistence.Configurations.Converters.Json;

public sealed class FlowLinkIdJsonConverter : JsonConverter<FlowLinkId>
{
    public override FlowLinkId Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException();
        }

        var guid = reader.GetGuid();
        return new FlowLinkId(guid);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FlowLinkId value,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value.ToString());
    }
}