using ChatbotBuilderApi.Domain.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ChatbotBuilderApi.Presentation.Users.Extensions;

public static class IdentityApiExtensions
{
    public static void MapIdentityEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("api/v1/users/identity")
            .WithTags("Users")
            .MapIdentityApi<User>();
    }
}