﻿using ChatbotBuilderApi.Domain.Graphs.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Ports.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Ports;

internal sealed class InputPortConfiguration : IEntityTypeConfiguration<Port<InputPortId>>
{
    public void Configure(EntityTypeBuilder<Port<InputPortId>> builder)
    {
        builder.ConfigurePortBase<Port<InputPortId>, InputPortId>();

        builder.HasDiscriminator<string>("DataType")
            .HasValue<InputPort<TextData>>(nameof(TextData))
            .HasValue<InputPort<OptionData>>(nameof(OptionData))
            .HasValue<InputPort<ImageData>>(nameof(ImageData));

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ApplyEntityIdConversion();
    }
}

internal sealed class TextInputPortConfiguration : IEntityTypeConfiguration<InputPort<TextData>>
{
    public void Configure(EntityTypeBuilder<InputPort<TextData>> builder)
    {
        builder.OwnsOne(p => p.Data, d => d.ConfigureTextData());
    }
}

internal sealed class OptionInputPortConfiguration : IEntityTypeConfiguration<InputPort<OptionData>>
{
    public void Configure(EntityTypeBuilder<InputPort<OptionData>> builder)
    {
        builder.OwnsOne(p => p.Data, d => d.ConfigureOptionData());
    }
}

internal sealed class ImageInputPortConfiguration : IEntityTypeConfiguration<InputPort<ImageData>>
{
    public void Configure(EntityTypeBuilder<InputPort<ImageData>> builder)
    {
        builder.OwnsOne(p => p.Data, d => d.ConfigureImageData());
    }
}