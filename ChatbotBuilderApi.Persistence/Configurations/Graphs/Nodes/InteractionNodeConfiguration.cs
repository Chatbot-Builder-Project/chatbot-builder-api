using ChatbotBuilderApi.Domain.Graphs.Entities.Nodes;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using ChatbotBuilderApi.Persistence.Configurations.Converters;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes;

internal sealed class InteractionNodeConfiguration : IEntityTypeConfiguration<InteractionNode>
{
    public void Configure(EntityTypeBuilder<InteractionNode> builder)
    {
        builder.ConfigureNodeBase();

        builder.HasOne(n => n.TextInputPort)
            .WithOne()
            .HasForeignKey<InteractionNode>()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.TextOutputPort)
            .WithOne()
            .HasForeignKey<InteractionNode>()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.OutputEnum)
            .WithMany()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.OptionOutputPort)
            .WithOne()
            .HasForeignKey<InteractionNode>()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(n => n.OutputOptionMetas)
            .HasConversion(new NullableDictionaryJsonConverter<OptionData, InteractionOptionMeta>())
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired(false);

        // Nested owned entity with Nullability cause issues
        // Hence we are using HasOne with WithOne instead of OwnsOne
        builder.HasOne(n => n.InteractionInput)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey<InteractionInput>("InteractionNodeId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction); // Issue
    }
}