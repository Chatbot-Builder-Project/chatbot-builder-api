﻿using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;

namespace ChatbotBuilderApi.Domain.Conversations.ValueObjects;

public sealed class OutputMessage : ValueObject
{
    public DateTime CreatedAt { get; }
    public InteractionOutput Output { get; } = null!;

    private OutputMessage(
        DateTime createdAt,
        InteractionOutput output)
    {
        CreatedAt = createdAt;
        Output = output;
    }

    /// <inheritdoc/>
    private OutputMessage()
    {
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CreatedAt;
        yield return Output;
    }

    public static OutputMessage Create(InteractionOutput output) => new(DateTime.UtcNow, output);
}