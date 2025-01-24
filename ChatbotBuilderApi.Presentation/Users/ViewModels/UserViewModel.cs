using ChatbotBuilderApi.Presentation.Graphs.Data;

namespace ChatbotBuilderApi.Presentation.Users.ViewModels;

/// <summary>
/// View model for a user.
/// </summary>
/// <param name="Id">ID of the user.</param>
/// <param name="UserName">Username of the user.</param>
/// <param name="Email">Email of the user.</param>
/// <param name="FirstName">First name of the user. If any.</param>
/// <param name="LastName">Last name of the user. If any.</param>
/// <param name="ProfileImage">Profile image of the user. If any.</param>
public sealed record UserViewModel(
    Guid Id,
    string UserName,
    string Email,
    string? FirstName,
    string? LastName,
    ImageDataModel? ProfileImage);