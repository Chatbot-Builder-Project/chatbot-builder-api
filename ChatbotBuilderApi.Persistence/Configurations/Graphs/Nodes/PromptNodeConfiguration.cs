using ChatbotBuilderApi.Domain.Graphs.Entities.Nodes.Prompt;
using ChatbotBuilderApi.Domain.Graphs.Entities.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes;

internal sealed class PromptNodeConfiguration : IEntityTypeConfiguration<PromptNode>
{
    public void Configure(EntityTypeBuilder<PromptNode> builder)
    {
        builder.ConfigureNodeBase();

        builder.OwnsOne(n => n.Template, b => b.Property(t => t.Text));

        builder.HasOne(n => n.OutputPort)
            .WithOne()
            .HasForeignKey<OutputPort<TextData>>(p => p.NodeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(n => n.InputPorts)
            .WithOne()
            .HasForeignKey(p => p.NodeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(n => n.InjectedTemplate);
    }
}