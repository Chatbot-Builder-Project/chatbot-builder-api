using System.Reflection;

namespace ChatbotBuilderApi.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}