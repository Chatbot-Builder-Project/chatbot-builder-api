using System.Text.Json;
using System.Text.Json.Serialization;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;

namespace ChatbotBuilderApi.Persistence.Configurations.Converters.Json;

public sealed class InteractionOptionMetaJsonConverter : JsonConverter<InteractionOptionMeta>
{
    public override InteractionOptionMeta Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        string? description = null;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                break;

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();

                reader.Read(); // Move to the value

                if (propertyName == nameof(InteractionOptionMeta.Description))
                {
                    description = reader.GetString();
                }
            }
        }

        if (description is null)
        {
            throw new JsonException("Missing required property Description");
        }

        return InteractionOptionMeta.Create(description);
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionOptionMeta value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString(nameof(InteractionOptionMeta.Description), value.Description);
        writer.WriteEndObject();
    }
}