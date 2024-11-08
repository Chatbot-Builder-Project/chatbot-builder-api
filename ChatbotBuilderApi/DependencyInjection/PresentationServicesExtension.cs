using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using ChatbotBuilderApi.Presentation.Filters;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace ChatbotBuilderApi.DependencyInjection;

public static class PresentationServicesExtension
{
    public static void AddPresentationServices(this IServiceCollection services)
    {
        services.AddProblemDetails();

        services
            .AddControllers(options =>
            {
                options.Filters.Add(new ValidationExceptionFilter());
                options.Filters.Add(new JsonPatchExceptionFilter());
            })
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

    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Add Newtonsoft.Json Support
        services.AddSwaggerGenNewtonsoftSupport();

        // Add fluent validation rules documentation
        services.AddFluentValidationRulesToSwagger(options =>
        {
            options.SetNotNullableIfMinLengthGreaterThenZero = true;
            options.UseAllOfForMultipleRules = true;
        });

        services.AddSwaggerGen(options =>
        {
            var apiVersionDescriptionProvider = services
                .BuildServiceProvider()
                .GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, new OpenApiInfo
                {
                    Title = $"Chatbot Builder API {description.ApiVersion}",
                    Version = description.ApiVersion.ToString()
                });
            }

            // Add XML output from documented assemblies
            var documentedAssemblies = new List<Assembly>
            {
                Presentation.AssemblyReference.Assembly,
                Application.AssemblyReference.Assembly
            };
            foreach (var assembly in documentedAssemblies)
            {
                var xmlFile = $"{assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            }
        });
    }
}