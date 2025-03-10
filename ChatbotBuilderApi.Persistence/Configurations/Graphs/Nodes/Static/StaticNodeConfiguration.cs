﻿using ChatbotBuilderApi.Domain.Graphs.Nodes;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Static;

internal sealed class TextStaticNodeConfiguration : IEntityTypeConfiguration<StaticNode<TextData>>
{
    public void Configure(EntityTypeBuilder<StaticNode<TextData>> builder)
    {
        builder.ConfigureStaticNode(d => d.ConfigureTextData());
    }
}

internal sealed class OptionStaticNodeConfiguration : IEntityTypeConfiguration<StaticNode<OptionData>>
{
    public void Configure(EntityTypeBuilder<StaticNode<OptionData>> builder)
    {
        builder.ConfigureStaticNode(d => d.ConfigureOptionData());
    }
}

internal sealed class ImageStaticNodeConfiguration : IEntityTypeConfiguration<StaticNode<ImageData>>
{
    public void Configure(EntityTypeBuilder<StaticNode<ImageData>> builder)
    {
        builder.ConfigureStaticNode(d => d.ConfigureImageData());
    }
}