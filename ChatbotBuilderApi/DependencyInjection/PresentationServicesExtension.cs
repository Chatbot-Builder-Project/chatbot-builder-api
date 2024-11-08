using Asp.Versioning;
using Newtonsoft.Json.Converters;

namespace ChatbotBuilderApi.DependencyInjection;

public static class PresentationServicesExtension
{
    public static void AddPresentationServices(this IServiceCollection services)
    {
        services.AddProblemDetails();

        services
            .AddControllers()
            .AddApplicationPart(Presentation.AssemblyReference.Assembly)
            .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

        services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
    }
}