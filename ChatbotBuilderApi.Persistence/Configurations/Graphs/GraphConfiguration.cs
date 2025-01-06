using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs;

internal sealed class GraphConfiguration : IEntityTypeConfiguration<Graph>
{
    public void Configure(EntityTypeBuilder<Graph> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ApplyEntityIdConversion();

        builder.Property(g => g.StartNodeId).ApplyEntityIdConversion();
        builder.Property(g => g.CurrentNodeId).ApplyEntityIdConversion();

        builder.HasMany(g => g.Enums)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.InputPorts)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.OutputPorts)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.Nodes)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.FlowLinks)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.DataLinks)
            .WithOne()
            .HasForeignKey("GraphId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(g => g.Enums).AutoInclude();
        builder.Navigation(g => g.Nodes).AutoInclude();
        builder.Navigation(g => g.DataLinks).AutoInclude();
        builder.Navigation(g => g.FlowLinks).AutoInclude();
        builder.Navigation(g => g.InputPorts).AutoInclude();
        builder.Navigation(g => g.OutputPorts).AutoInclude();
    }
}