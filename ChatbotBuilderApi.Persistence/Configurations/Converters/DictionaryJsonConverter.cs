using System.Text.Json;
using ChatbotBuilderApi.Domain.Core.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatbotBuilderApi.Persistence.Configurations.Converters;

/// <remarks>
/// When serializing a dictionary, update operations on the dictionary will not be tracked by EF Core.
/// So you would need to call <see cref="DbContext.Update{TEntity}(TEntity)"/> explicitly on the entity.
/// </remarks>
public class DictionaryJsonConverter<TKey, TValue> : ValueConverter<IReadOnlyDictionary<TKey, TValue>, string>
    where TKey : ValueObject
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        Converters = { new HashedDictionaryJsonConverter<TKey, TValue>() },
        WriteIndented = false
    };

    public DictionaryJsonConverter() : base(
        dict => JsonSerializer.Serialize(dict, JsonOptions),
        json => JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(json, JsonOptions)
                ?? new Dictionary<TKey, TValue>())
    {
    }
}

public class NullableDictionaryJsonConverter<TKey, TValue>
    : ValueConverter<IReadOnlyDictionary<TKey, TValue>?, string>
    where TKey : ValueObject
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        Converters = { new HashedDictionaryJsonConverter<TKey, TValue>() },
        WriteIndented = false
    };

    public NullableDictionaryJsonConverter() : base(
        dict => dict == null
            ? null!
            : JsonSerializer.Serialize(dict, JsonOptions),
        json => string.IsNullOrEmpty(json)
            ? null
            : JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(json, JsonOptions))
    {
    }
}