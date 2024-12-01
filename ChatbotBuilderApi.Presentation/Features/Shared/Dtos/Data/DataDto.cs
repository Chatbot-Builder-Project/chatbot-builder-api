using ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Workflows.Enums;
using JsonSubTypes;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace ChatbotBuilderApi.Presentation.Features.Shared.Dtos.Data;

[JsonConverter(typeof(JsonSubtypes), nameof(DataType))]
[JsonSubtypes.KnownSubType(typeof(TextDataDto), DataType.Text)]
[JsonSubtypes.KnownSubType(typeof(ImageDataDto), DataType.Image)]
[JsonSubtypes.KnownSubType(typeof(OptionDataDto), DataType.Option)]
[SwaggerDiscriminator(nameof(DataType))]
[SwaggerSubType(typeof(TextDataDto), DiscriminatorValue = nameof(DataType.Text))]
[SwaggerSubType(typeof(ImageDataDto), DiscriminatorValue = nameof(DataType.Image))]
[SwaggerSubType(typeof(OptionDataDto), DiscriminatorValue = nameof(DataType.Option))]
public abstract class DataDto
{
    public DataType DataType { get; set; }
}