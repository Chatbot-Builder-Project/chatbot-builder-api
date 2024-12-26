using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Users;

public sealed class UserId : EntityId<UserId>
{
    public UserId(Guid value) : base(value)
    {
    }
}