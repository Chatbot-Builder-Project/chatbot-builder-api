namespace ChatbotBuilderApi.WebApplicationExtensions;

public static class SwaggerWebApplicationExtensions
{
    public static void AddSwaggerGen(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in app.DescribeApiVersions())
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });
    }
}