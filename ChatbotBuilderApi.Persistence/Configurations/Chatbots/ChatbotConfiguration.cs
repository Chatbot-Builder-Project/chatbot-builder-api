using ChatbotBuilderApi.Domain.Chatbots;
using ChatbotBuilderApi.Domain.Workflows;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Chatbots;

internal sealed class ChatbotConfiguration : IEntityTypeConfiguration<Chatbot>
{
    public void Configure(EntityTypeBuilder<Chatbot> builder)
    {
        builder.ConfigureAggregateRoot();

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ApplyEntityIdConversion();

        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Description).IsRequired();

        builder.HasOne<Workflow>()
            .WithMany()
            .HasForeignKey(c => c.WorkflowId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Graph)
            .WithMany()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.OwnsOne(c => c.Version, versionBuilder =>
        {
            versionBuilder.Property(v => v.Major)
                .HasColumnName("VersionMajor")
                .IsRequired();

            // Add shadow property to use in index
            builder.Property<int>("VersionMajor")
                .HasColumnName("VersionMajor");
        });

        builder.Property(c => c.IsPublic)
            .HasColumnName("IsPublic")
            .IsRequired();

        builder.HasIndex("IsPublic", "VersionMajor")
            .IsUnique();
    }
}