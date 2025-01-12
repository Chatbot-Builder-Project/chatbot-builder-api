using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatbotBuilderApi.Persistence.Configurations.Converters;

public class JObjectValueConverter : ValueConverter<JObject?, string>
{
    public JObjectValueConverter()
        : base(
            v => v == null ? string.Empty : v.ToString(Formatting.None),
            v => string.IsNullOrEmpty(v) ? null : JObject.Parse(v))
    {
    }
}