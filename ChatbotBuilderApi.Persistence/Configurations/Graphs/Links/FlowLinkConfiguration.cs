﻿using ChatbotBuilderApi.Domain.Graphs.Links;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Links.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Links;

internal sealed class FlowLinkConfiguration : IEntityTypeConfiguration<FlowLink>
{
    public void Configure(EntityTypeBuilder<FlowLink> builder)
    {
        builder.ConfigureLinkBase<FlowLink, FlowLinkId>();

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ApplyEntityIdConversion();

        builder.Property(l => l.SourceNodeId).ApplyEntityIdConversion();
        builder.Property(l => l.TargetNodeId).ApplyEntityIdConversion();
    }
}