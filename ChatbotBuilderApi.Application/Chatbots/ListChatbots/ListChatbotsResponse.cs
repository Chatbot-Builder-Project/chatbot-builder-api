using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Chatbots.ListChatbots;

public sealed record ListChatbotsResponse(PageResponse<ListChatbotsResponseItem> Page);

public sealed record ListChatbotsResponseItem(
    ChatbotId Id,
    UserId OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    bool IsPublic,
    VisualMeta Visual,
    ImageData? AvatarImageData);