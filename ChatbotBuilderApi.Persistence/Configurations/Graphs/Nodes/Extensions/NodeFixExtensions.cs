using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;

public static class NodeFixExtensions
{
    /// <summary>
    /// Fix the node's port to be nullable.
    /// Let the application layer handle the validation.
    /// Otherwise, Graph creation throws an exception.
    /// Because both the node and the graph have a reference to the port.
    /// So, the order of insertion must be determined for the database to be able to insert the data.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="portNavigationName"></param>
    /// <typeparam name="TId">InputPortId or OutputPortId</typeparam>
    public static void FixNodePort<TId>(
        this EntityTypeBuilder builder,
        string portNavigationName)
        where TId : EntityId<TId>
    {
        var name = portNavigationName + "Id";

        builder.Property<TId>(name)
            .IsRequired(false)
            .HasColumnName(name);

        builder.HasIndex(name)
            .IsUnique()
            .HasFilter($"[{name}] IS NOT NULL");
    }

    /// <summary>
    /// Fix the node's enum to be nullable.
    /// Let the application layer handle the validation.
    /// Otherwise, Graph creation throws an exception.
    /// Because both the node and the graph have a reference to the enum.
    /// So, the order of insertion must be determined for the database to be able to insert the data.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="enumNavigationName"></param>
    public static void FixNodeEnum(
        this EntityTypeBuilder builder,
        string enumNavigationName)
    {
        var name = enumNavigationName + "Id";

        builder.Property<EnumId>(name)
            .IsRequired(false)
            .HasColumnName(name);

        builder.HasIndex(name)
            .IsUnique()
            .HasFilter($"[{name}] IS NOT NULL");
    }
}