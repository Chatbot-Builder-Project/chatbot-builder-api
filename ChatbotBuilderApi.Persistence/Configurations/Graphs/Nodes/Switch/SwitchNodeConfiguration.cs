using ChatbotBuilderApi.Domain.Graphs.Nodes.Switch;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Switch;

internal sealed class SwitchNodeConfiguration : IEntityTypeConfiguration<SwitchNode>
{
    public void Configure(EntityTypeBuilder<SwitchNode> builder)
    {
        builder.ConfigureSwitchNodeBase();

        builder.HasOne(n => n.InputPort)
            .WithOne()
            .HasForeignKey<SwitchNode>()
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(n => n.InputPort).AutoInclude();

        builder.FixNodePort<InputPortId>(nameof(SwitchNode.InputPort));
    }
}