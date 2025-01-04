using ChatbotBuilderApi.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace ChatbotBuilderApi.Application.Users;

public sealed class UserFieldsValidator : IUserValidator<User>
{
    public async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
    {
        var errors = new List<IdentityError>();

        if (user.FirstName?.Length > 100)
        {
            errors.Add(new IdentityError { Description = "First name cannot exceed 100 characters." });
        }

        if (user.LastName?.Length > 100)
        {
            errors.Add(new IdentityError { Description = "Last name cannot exceed 100 characters." });
        }

        if (string.IsNullOrWhiteSpace(user.UserName))
        {
            errors.Add(new IdentityError { Description = "Username is required." });
        }
        else if (user.UserName.Length > 50)
        {
            errors.Add(new IdentityError { Description = "Username cannot exceed 50 characters." });
        }
        else
        {
            var existingUser = await manager.FindByNameAsync(user.UserName);
            if (existingUser != null && existingUser.Id != user.Id)
            {
                errors.Add(new IdentityError { Description = "This username is already taken." });
            }
        }

        return errors.Count > 0
            ? IdentityResult.Failed(errors.ToArray())
            : IdentityResult.Success;
    }
}