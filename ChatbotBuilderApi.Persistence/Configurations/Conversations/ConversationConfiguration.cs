using ChatbotBuilderApi.Domain.Chatbots;
using ChatbotBuilderApi.Domain.Conversations;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Conversations;

internal sealed class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
{
    public void Configure(EntityTypeBuilder<Conversation> builder)
    {
        builder.ConfigureAggregateRoot();

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ApplyEntityIdConversion();

        builder.Property(c => c.Name);

        builder.HasOne<Chatbot>()
            .WithMany()
            .HasForeignKey(c => c.ChatbotId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        builder.Property(c => c.ChatbotId).ApplyEntityIdConversion();

        builder.HasOne<Graph>()
            .WithOne()
            .HasForeignKey<Graph>("ConversationId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        // Owned entities cannot have navigation properties
        // So we are using HasMany instead of OwnsMany
        builder.HasMany(c => c.InputMessages)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(c => c.OutputMessages)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}