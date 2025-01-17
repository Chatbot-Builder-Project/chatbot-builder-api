using System.Text.Json;
using System.Text.Json.Serialization;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;

namespace ChatbotBuilderApi.Persistence.Configurations.Converters.Json;

public sealed class ImageDataJsonConverter : JsonConverter<ImageData>
{
    public override ImageData Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        string? url = null;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                break;

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();

                reader.Read(); // Move to the value

                if (propertyName == nameof(ImageData.Url))
                {
                    url = reader.GetString();
                }
            }
        }

        if (url is null)
        {
            throw new JsonException("Missing required property Url");
        }

        return ImageData.Create(url);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImageData value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString(nameof(ImageData.Url), value.Url);
        writer.WriteEndObject();
    }
}