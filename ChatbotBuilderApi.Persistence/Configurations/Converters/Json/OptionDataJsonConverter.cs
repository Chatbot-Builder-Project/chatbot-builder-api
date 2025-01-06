using System.Text.Json;
using System.Text.Json.Serialization;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;

namespace ChatbotBuilderApi.Persistence.Configurations.Converters.Json;

public sealed class OptionDataJsonConverter : JsonConverter<OptionData>
{
    public override OptionData Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException();

        string? value = null;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                break;

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();

                reader.Read(); // Move to the value

                if (propertyName == nameof(OptionData.Value))
                {
                    value = reader.GetString();
                }
            }
        }

        if (value is null)
        {
            throw new JsonException("Missing required property Value");
        }

        return OptionData.Create(value);
    }

    public override void Write(
        Utf8JsonWriter writer,
        OptionData value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString(nameof(OptionData.Value), value.Value);
        writer.WriteEndObject();
    }

    // For serialization as a key in a dictionary
    public override OptionData ReadAsPropertyName(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var value = reader.GetString() ?? throw new JsonException();
        return OptionData.Create(value);
    }

    // For serialization as a key in a dictionary
    public override void WriteAsPropertyName(
        Utf8JsonWriter writer,
        OptionData value,
        JsonSerializerOptions options)
    {
        writer.WritePropertyName(value.Value);
    }
}