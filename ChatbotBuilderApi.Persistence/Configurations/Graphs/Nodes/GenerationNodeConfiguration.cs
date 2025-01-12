using ChatbotBuilderApi.Domain.Graphs.Nodes.Generation;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Converters;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes;

internal sealed class GenerationNodeConfiguration : IEntityTypeConfiguration<GenerationNode>
{
    public void Configure(EntityTypeBuilder<GenerationNode> builder)
    {
        builder.HasOne(n => n.InputPort)
            .WithOne()
            .HasForeignKey<GenerationNode>()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.OutputPort)
            .WithOne()
            .HasForeignKey<GenerationNode>()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(n => n.InputPort).AutoInclude();
        builder.Navigation(n => n.OutputPort).AutoInclude();

        builder.FixNodePort<InputPortId>(nameof(GenerationNode.InputPort));
        builder.FixNodePort<OutputPortId>(nameof(GenerationNode.OutputPort));

        builder.OwnsOne(n => n.Options, config =>
        {
            config.Property(o => o.UseMemory).IsRequired();
            config.Property(o => o.ResponseSchema)
                .HasConversion(new JObjectValueConverter())
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired(false);
        });

        builder.OwnsOne(n => n.GeneratedOutput, config => config.ConfigureTextData());
    }
}