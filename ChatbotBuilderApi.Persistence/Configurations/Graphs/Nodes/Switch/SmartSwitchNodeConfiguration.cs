using ChatbotBuilderApi.Domain.Graphs.Nodes.Switch;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Switch;

internal sealed class SmartSwitchNodeConfiguration : IEntityTypeConfiguration<SmartSwitchNode>
{
    public void Configure(EntityTypeBuilder<SmartSwitchNode> builder)
    {
        builder.ConfigureSwitchNodeBase();

        builder.HasOne(n => n.InputPort)
            .WithOne()
            .HasForeignKey<SmartSwitchNode>()
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(n => n.FallbackFlowLinkId)
            .ApplyEntityIdConversion();

        builder.Navigation(n => n.InputPort).AutoInclude();

        builder.FixNodePort<InputPortId>(nameof(SmartSwitchNode.InputPort));
    }
}