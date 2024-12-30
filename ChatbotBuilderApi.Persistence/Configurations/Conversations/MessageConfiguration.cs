using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Conversations;

internal sealed class InputMessageConfiguration : IEntityTypeConfiguration<InputMessage>
{
    public void Configure(EntityTypeBuilder<InputMessage> builder)
    {
        builder.Property<Guid>("Id").ValueGeneratedOnAdd();
        builder.HasKey("Id");

        builder.Property(i => i.CreatedAt);

        builder.HasOne(i => i.Input)
            .WithOne()
            .HasForeignKey<InteractionInput>("InputMessageId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(i => i.Input).AutoInclude();
    }
}

internal sealed class OutputMessageConfiguration : IEntityTypeConfiguration<OutputMessage>
{
    public void Configure(EntityTypeBuilder<OutputMessage> builder)
    {
        builder.Property<Guid>("Id").ValueGeneratedOnAdd();
        builder.HasKey("Id");

        builder.Property(o => o.CreatedAt);

        builder.HasOne(o => o.Output)
            .WithOne()
            .HasForeignKey<InteractionOutput>("OutputMessageId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(o => o.Output).AutoInclude();
    }
}