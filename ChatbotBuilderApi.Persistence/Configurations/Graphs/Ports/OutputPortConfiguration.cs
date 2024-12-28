using ChatbotBuilderApi.Domain.Graphs.Abstract;
using ChatbotBuilderApi.Domain.Graphs.Entities.Ports;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderApi.Persistence.Configurations.Extensions;
using ChatbotBuilderApi.Persistence.Configurations.Graphs.Ports.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatbotBuilderApi.Persistence.Configurations.Graphs.Ports;

internal sealed class OutputPortConfiguration : IEntityTypeConfiguration<Port<OutputPortId>>
{
    public void Configure(EntityTypeBuilder<Port<OutputPortId>> builder)
    {
        builder.ConfigurePortBase<Port<OutputPortId>, OutputPortId>();

        builder.HasDiscriminator<string>("DataType")
            .HasValue<OutputPort<TextData>>(nameof(TextData))
            .HasValue<OutputPort<OptionData>>(nameof(OptionData))
            .HasValue<OutputPort<ImageData>>(nameof(ImageData));

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ApplyEntityIdConversion();
    }
}

internal sealed class TextOutputPortConfiguration : IEntityTypeConfiguration<OutputPort<TextData>>
{
    public void Configure(EntityTypeBuilder<OutputPort<TextData>> builder)
    {
        builder.ConfigureOutputPort("TextOutputPortInputPort");
    }
}

internal sealed class OptionOutputPortConfiguration : IEntityTypeConfiguration<OutputPort<OptionData>>
{
    public void Configure(EntityTypeBuilder<OutputPort<OptionData>> builder)
    {
        builder.ConfigureOutputPort("OptionOutputPortInputPort");
    }
}

internal sealed class ImageOutputPortConfiguration : IEntityTypeConfiguration<OutputPort<ImageData>>
{
    public void Configure(EntityTypeBuilder<OutputPort<ImageData>> builder)
    {
        builder.ConfigureOutputPort("ImageOutputPortInputPort");
    }
}