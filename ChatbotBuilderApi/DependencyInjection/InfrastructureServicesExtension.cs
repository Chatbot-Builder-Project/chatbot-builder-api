using System.Text;
using ChatbotBuilderApi.Domain.Shared;
using ChatbotBuilderApi.Infrastructure.PipelineBehaviors;
using ChatbotBuilderApi.Infrastructure.Settings;
using ChatbotBuilderApi.Presentation.Constants;
using ChatbotBuilderApi.Presentation.Shared.ResultExtensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ChatbotBuilderApi.DependencyInjection;

public static class InfrastructureServicesExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        services.AddJwtAuthentication();
    }

    private static void AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var jwtSettings = serviceProvider.GetRequiredService<IOptions<JwtSettings>>().Value;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),

                };

                options.Events = new JwtBearerEvents
                {
                    // Custom authorization failure to return ProblemDetails response
                    OnAuthenticationFailed = context =>
                    {
                        context.NoResult();

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = PresentationRules.ContentTypes.ProblemJson;

                        var error = PresentationErrors
                            .AuthenticationFailed(context.Exception.Message);

                        var problemDetails = Result
                            .Failure(error)
                            .ToProblemDetails()
                            .Value as ProblemDetails;

                        return context.Response.WriteAsJsonAsync(problemDetails);
                    }
                };
            });
    }
}