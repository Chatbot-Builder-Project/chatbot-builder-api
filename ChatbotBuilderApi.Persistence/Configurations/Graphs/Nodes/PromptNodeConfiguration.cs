using ChatbotBuilderApi.Domain.Graphs.Nodes.Prompt;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes;

internal sealed class PromptNodeConfiguration : IEntityTypeConfiguration<PromptNode>
{
    public void Configure(EntityTypeBuilder<PromptNode> builder)
    {
        builder.OwnsOne(n => n.Template, b => b.Property(t => t.Text));

        builder.Property(n => n.InjectedTemplate);

        builder.HasOne(n => n.OutputPort)
            .WithOne()
            .HasForeignKey<PromptNode>()
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(n => n.InputPorts)
            .WithOne()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(n => n.OutputPort).AutoInclude();
        builder.Navigation(n => n.InputPorts).AutoInclude();

        builder.FixNodePort<OutputPortId>(nameof(PromptNode.OutputPort));
    }
}