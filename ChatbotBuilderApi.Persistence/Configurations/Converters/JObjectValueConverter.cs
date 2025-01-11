using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatbotBuilderApi.Persistence.Configurations.Converters;

public class JObjectValueConverter : ValueConverter<JObject, string>
{
    public JObjectValueConverter()
        : base(
            v => v.ToString(Formatting.None),
            v => JObject.Parse(v))
    {
    }
}