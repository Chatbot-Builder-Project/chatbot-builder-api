using System.Reflection;

namespace ChatbotBuilderApi.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}