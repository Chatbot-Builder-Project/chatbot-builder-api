namespace ChatbotBuilderApi.Presentation.Users.ViewModels;

public sealed record UserViewModel(
    Guid Id,
    string UserName,
    string Email,
    string? FirstName,
    string? LastName);