using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderApi.Application.Conversations.ListMessages;

public sealed record ListMessagesResponse(
    PageResponse<InputMessage> InputMessagesPage,
    PageResponse<OutputMessage> OutputMessagesPage);