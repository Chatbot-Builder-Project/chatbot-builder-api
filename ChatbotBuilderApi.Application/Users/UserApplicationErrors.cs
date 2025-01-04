using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Application.Users;

public static class UserApplicationErrors
{
    public static readonly Error UserNotFound = Error.NotFound(
        "Users.UserNotFound",
        "User not found.");

    public static readonly Error OldPasswordRequired = Error.BadRequest(
        "Users.OldPasswordRequired",
        "Old password is required.");
}