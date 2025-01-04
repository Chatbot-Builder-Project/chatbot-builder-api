namespace ChatbotBuilderApi.Presentation.Users.Requests;

public sealed class RegisterUserRequest
{
    public required string UserName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}