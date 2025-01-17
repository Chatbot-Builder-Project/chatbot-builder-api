using System.Text.Json;
using System.Text.Json.Serialization;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;

namespace ChatbotBuilderApi.Persistence.Configurations.Converters.Json;

public sealed class InteractionOptionMetaJsonConverter : JsonConverter<InteractionOptionMeta>
{
    private readonly JsonConverter<ImageData> _imageDataConverter;

    public InteractionOptionMetaJsonConverter(JsonConverter<ImageData> imageDataConverter)
    {
        _imageDataConverter = imageDataConverter;
    }

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
        ImageData? imageData = null;

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
                else if (propertyName == nameof(InteractionOptionMeta.ImageData))
                {
                    if (reader.TokenType == JsonTokenType.StartObject)
                    {
                        imageData = _imageDataConverter.Read(ref reader, typeof(ImageData), options);
                    }
                }
            }
        }

        if (description is null)
        {
            throw new JsonException("Missing required property Description");
        }

        return InteractionOptionMeta.Create(description, imageData);
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionOptionMeta value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString(nameof(InteractionOptionMeta.Description), value.Description);

        if (value.ImageData is not null)
        {
            writer.WritePropertyName(nameof(InteractionOptionMeta.ImageData));
            _imageDataConverter.Write(writer, value.ImageData, options);
        }

        writer.WriteEndObject();
    }
}