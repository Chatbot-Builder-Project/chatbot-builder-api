using ChatbotBuilderApi.Domain.Graphs.Nodes.Switch;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Converters;
using ChatbotBuilderApi.Persistence.Configurations.Converters.Json;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Nodes.Switch;

internal static class SwitchNodeConfigurationExtension
{
    public static void ConfigureSwitchNodeBase<TSwitch>(
        this EntityTypeBuilder<TSwitch> builder)
        where TSwitch : SwitchNodeBase
    {
        builder.HasOne(n => n.Enum)
            .WithMany()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(n => n.Enum).AutoInclude();

        builder.FixNodeEnum(nameof(SwitchNodeBase.Enum));

        builder.Property(n => n.Bindings)
            .HasConversion(new DictionaryValueConverter<OptionData, FlowLinkId>(
                new OptionDataJsonConverter(),
                new FlowLinkIdJsonConverter()))
            .HasColumnType("NVARCHAR(MAX)");

        builder.OwnsOne(n => n.SelectedOption, n => n.ConfigureOptionData());
    }
}