using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using JsonSubTypes;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace ChatbotBuilderApi.Presentation.Graphs.Data;

[JsonConverter(typeof(JsonSubtypes), nameof(DataType))]
[JsonSubtypes.KnownSubType(typeof(TextDataModel), DataType.Text)]
[JsonSubtypes.KnownSubType(typeof(OptionDataModel), DataType.Option)]
[JsonSubtypes.KnownSubType(typeof(ImageDataModel), DataType.Image)]
[SwaggerDiscriminator(nameof(DataType))]
[SwaggerSubType(typeof(TextDataModel), DiscriminatorValue = nameof(DataType.Text))]
[SwaggerSubType(typeof(OptionDataModel), DiscriminatorValue = nameof(DataType.Option))]
[SwaggerSubType(typeof(ImageDataModel), DiscriminatorValue = nameof(DataType.Image))]
public abstract record DataModel(DataType Type);