using System.Text.Json;
using System.Text.Json.Serialization;
using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Persistence.Configurations.Converters;

/// <summary>
/// Converts a dictionary to a JSON using the hash of the key as the key in the JSON
/// and the key-value pair as the value.
/// </summary>
public class HashedDictionaryJsonConverter<TKey, TValue> : JsonConverter<IReadOnlyDictionary<TKey, TValue>?>
    where TKey : ValueObject
{
    public override IReadOnlyDictionary<TKey, TValue>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        var result = new Dictionary<TKey, TValue>();
        var jsonObject = JsonSerializer.Deserialize<Dictionary<string, HashContainer>>(ref reader, options);

        foreach (var kvp in jsonObject!)
        {
            var key = JsonSerializer.Deserialize<TKey>(JsonSerializer.Serialize(kvp.Value.Key), options);
            result[key!] = kvp.Value.Value!;
        }

        return result;
    }

    public override void Write(
        Utf8JsonWriter writer,
        IReadOnlyDictionary<TKey, TValue>? value,
        JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        var serializedDictionary = value.ToDictionary(
            kvp => kvp.Key.GetHashCode().ToString(), // Use the hash as the key
            kvp => new HashContainer
            {
                Key = kvp.Key,
                Value = kvp.Value
            });

        JsonSerializer.Serialize(writer, serializedDictionary, options);
    }

    private class HashContainer
    {
        public TKey? Key { get; init; }
        public TValue? Value { get; init; }
    }
}