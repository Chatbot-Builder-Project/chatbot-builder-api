using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatbotBuilderApi.Persistence.Configurations.Converters;

/// <remarks>
/// When serializing a dictionary, update operations on the dictionary will not be tracked by EF Core.
/// So you would need to call <see cref="DbLoggerCategory.Update"/> explicitly on the entity.
/// </remarks>
public class DictionaryValueConverter<TKey, TValue> : ValueConverter<IReadOnlyDictionary<TKey, TValue>, string>
{
    public DictionaryValueConverter(
        JsonConverter<TKey>? keyConverter = null,
        JsonConverter<TValue>? valueConverter = null)
        : base(
            dict => JsonSerializer.Serialize(
                dict, CreateOptions(keyConverter, valueConverter)),
            json => JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(
                json, CreateOptions(keyConverter, valueConverter))!)
    {
    }

    internal static JsonSerializerOptions CreateOptions(
        JsonConverter<TKey>? keyConverter,
        JsonConverter<TValue>? valueConverter)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = false
        };

        if (keyConverter != null)
        {
            options.Converters.Add(keyConverter);
        }

        if (valueConverter != null)
        {
            options.Converters.Add(valueConverter);
        }

        return options;
    }
}

/// <summary>
/// JSON converter for nullable dictionaries.
/// </summary>
public class NullableDictionaryValueConverter<TKey, TValue> : ValueConverter<IReadOnlyDictionary<TKey, TValue>?, string>
{
    public NullableDictionaryValueConverter(
        JsonConverter<TKey>? keyConverter = null,
        JsonConverter<TValue>? valueConverter = null)
        : base(
            dict => dict == null
                ? null!
                : JsonSerializer.Serialize(dict, DictionaryValueConverter<TKey, TValue>
                    .CreateOptions(keyConverter, valueConverter)),
            json => string.IsNullOrEmpty(json)
                ? null
                : JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(json, DictionaryValueConverter<TKey, TValue>
                    .CreateOptions(keyConverter, valueConverter)))
    {
    }
}