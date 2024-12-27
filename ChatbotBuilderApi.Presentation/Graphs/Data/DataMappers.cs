using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderApi.Presentation.Graphs.Data;

[Mapper]
public static partial class DataMappers
{
    public static partial TextDataModel ToModel(this TextData domain);

    public static partial ImageDataModel ToModel(this ImageData domain);

    [MapProperty(nameof(OptionData.Value), nameof(OptionDataModel.Option))]
    public static partial OptionDataModel ToModel(this OptionData domain);

    public static TextData ToDomain(this TextDataModel model) => TextData.Create(model.Text);

    public static ImageData ToDomain(this ImageDataModel model) => ImageData.Create(model.Url);

    public static OptionData ToDomain(this OptionDataModel model) => OptionData.Create(model.Option);

    public static DataModel MapToModel(this Domain.Graphs.ValueObjects.Data.Data domain)
    {
        return domain switch
        {
            TextData textData => textData.ToModel(),
            ImageData imageData => imageData.ToModel(),
            OptionData optionData => optionData.ToModel(),
            _ => throw new ArgumentOutOfRangeException(nameof(domain))
        };
    }

    public static Domain.Graphs.ValueObjects.Data.Data MapToDomain(this DataModel model)
    {
        return model switch
        {
            TextDataModel textDataModel => textDataModel.ToDomain(),
            ImageDataModel imageDataModel => imageDataModel.ToDomain(),
            OptionDataModel optionDataModel => optionDataModel.ToDomain(),
            _ => throw new ArgumentOutOfRangeException(nameof(model))
        };
    }
}