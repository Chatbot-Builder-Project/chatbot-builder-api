using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Images;

internal sealed class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ConfigureAggregateRoot();

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ApplyEntityIdConversion();

        builder.Property(i => i.Url).IsRequired();
        builder.Property(i => i.Name).IsRequired();
        builder.Property(i => i.ContentType).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(i => i.OwnerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(i => i.OwnerId)
            .HasColumnName("OwnerId");

        builder.OwnsOne(i => i.Meta, metaBuilder =>
        {
            metaBuilder.Property(m => m.IsProfilePicture)
                .HasColumnName("IsProfilePicture")
                .IsRequired();

            // Add shadow property to use in index
            builder.Property<bool>("IsProfilePicture")
                .HasColumnName("IsProfilePicture");
        });

        builder.HasIndex("OwnerId", "IsProfilePicture");

        builder.HasIndex(i => i.Url).IsUnique();
    }
}