﻿using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderApi.Persistence.Configurations.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;

internal static class MetaConfigurationExtensions
{
    public static void ConfigureInfoMeta<T>(
        this OwnedNavigationBuilder<T, InfoMeta> builder)
        where T : class
    {
        builder.Property(d => d.Identifier)
            .IsRequired();

        builder.Property(d => d.Name)
            .IsRequired();
    }

    public static void ConfigureVisualMeta<T>(
        this OwnedNavigationBuilder<T, VisualMeta> builder)
        where T : class
    {
        builder.Property(v => v.Data)
            .HasConversion(new JObjectValueConverter())
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired(false);
    }
}