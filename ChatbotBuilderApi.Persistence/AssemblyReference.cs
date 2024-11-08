using System.Reflection;

namespace ChatbotBuilderApi.Persistence;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}