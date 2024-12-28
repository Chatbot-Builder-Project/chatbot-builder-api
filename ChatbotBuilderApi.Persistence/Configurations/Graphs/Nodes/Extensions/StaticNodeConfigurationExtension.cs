using ChatbotBuilderApi.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderApi.Domain.Graphs.Entities.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;

internal static class StaticNodeConfigurationExtension
{
    public static void ConfigureStaticNode<TData>(
        this EntityTypeBuilder<StaticNode<TData>> builder,
        Action<OwnedNavigationBuilder<StaticNode<TData>, TData>> configureData)
        where TData : Data
    {
        builder.ConfigureNodeBase();

        builder.OwnsOne(n => n.Data, configureData);

        builder.HasOne(n => n.OutputPort)
            .WithOne()
            .HasForeignKey<StaticNode<TData>>()
            .OnDelete(DeleteBehavior.NoAction);
    }
}