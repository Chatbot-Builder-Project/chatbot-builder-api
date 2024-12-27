using System.Reflection;

namespace ChatbotBuilderApi.Domain;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}