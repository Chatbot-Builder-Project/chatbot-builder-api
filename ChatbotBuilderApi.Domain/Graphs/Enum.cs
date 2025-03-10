﻿using ChatbotBuilderApi.Domain.Core;
using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderApi.Domain.Graphs;

public sealed class Enum : Entity<EnumId>
{
    public InfoMeta Info { get; } = null!;
    public VisualMeta Visual { get; } = null!;
    public IReadOnlySet<OptionData> Options { get; } = null!;

    private Enum(
        EnumId id,
        InfoMeta info,
        VisualMeta visual,
        IReadOnlySet<OptionData> options)
        : base(id)
    {
        Info = info;
        Visual = visual;
        Options = options;
    }

    /// <inheritdoc/>
    private Enum()
    {
    }

    public static Enum Create(
        EnumId id,
        InfoMeta info,
        VisualMeta visual,
        IReadOnlySet<OptionData> options)
    {
        return new Enum(id, info, visual, options);
    }

    public void EnsureValidBindings<T>(IReadOnlyDictionary<OptionData, T> mapping)
    {
        if (mapping.Count != Options.Count
            || Options.Any(option => !mapping.ContainsKey(option)))
        {
            throw new DomainException(GraphDomainErrors.Enum.InvalidMapping);
        }
    }
}