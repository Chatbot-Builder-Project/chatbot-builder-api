﻿using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Ports.Extensions;

internal static class PortConfigurationExtensions
{
    public static void ConfigurePortBase<TPort, TId>(this EntityTypeBuilder<TPort> builder)
        where TPort : Port<TId>
        where TId : EntityId<TId>
    {
        builder.Property(p => p.NodeId).ApplyEntityIdConversion();

        builder.OwnsOne(p => p.Info, i => i.ConfigureInfoMeta());
        builder.OwnsOne(p => p.Visual, v => v.ConfigureVisualMeta());
    }
}