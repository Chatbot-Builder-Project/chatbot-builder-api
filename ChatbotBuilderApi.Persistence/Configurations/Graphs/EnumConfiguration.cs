using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Enum = ChatbotBuilderApi.Domain.Graphs.Entities.Enum;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs;

internal sealed class EnumConfiguration : IEntityTypeConfiguration<Enum>
{
    public void Configure(EntityTypeBuilder<Enum> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ApplyEntityIdConversion();

        builder.OwnsOne(e => e.Info, i => i.ConfigureInfoMeta());
        builder.OwnsMany(e => e.Options, optionBuilder =>
        {
            optionBuilder
                .WithOwner()
                .HasForeignKey("EnumId");

            optionBuilder.ConfigureOptionData();
        });

        builder.Navigation(e => e.Options).AutoInclude();
    }
}