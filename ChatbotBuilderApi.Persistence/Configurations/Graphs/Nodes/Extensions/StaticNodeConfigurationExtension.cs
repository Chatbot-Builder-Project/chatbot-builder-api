using ChatbotBuilderApi.Domain.Graphs.Nodes;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
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
        builder.OwnsOne(n => n.Data, configureData);

        builder.HasOne(n => n.OutputPort)
            .WithOne()
            .HasForeignKey<StaticNode<TData>>("OutputPortId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(n => n.OutputPort).AutoInclude();

        builder.FixNodePort<OutputPortId>(nameof(StaticNode<TData>.OutputPort));
    }
}