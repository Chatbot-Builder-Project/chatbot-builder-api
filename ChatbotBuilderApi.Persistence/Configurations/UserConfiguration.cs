using ChatbotBuilderApi.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .IsRequired(false)
            .HasMaxLength(100);
    }
}