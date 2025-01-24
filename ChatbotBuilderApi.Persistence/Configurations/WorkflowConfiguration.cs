using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Domain.Workflows;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations;

internal sealed class WorkflowConfiguration : IEntityTypeConfiguration<Workflow>
{
    public void Configure(EntityTypeBuilder<Workflow> builder)
    {
        builder.ConfigureAggregateRoot();

        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id).ApplyEntityIdConversion();

        builder.Property(w => w.Name).IsRequired();
        builder.Property(w => w.Description).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(w => w.OwnerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(w => w.Graph)
            .WithMany()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.OwnsOne(w => w.Visual, v => v.ConfigureVisualMeta());
    }
}