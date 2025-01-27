using ChatbotBuilderApi.Domain.Chatbots;
using ChatbotBuilderApi.Domain.Conversations;
using ChatbotBuilderApi.Domain.Graphs;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
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
            .WithMany()
            .HasForeignKey(c => c.GraphId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(c => c.OwnerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

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

        builder.OwnsOne(c => c.Visual, v => v.ConfigureVisualMeta());
    }
}