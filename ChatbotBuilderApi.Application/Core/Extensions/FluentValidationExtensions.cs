using System.Text.RegularExpressions;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Core.Extensions;

public static partial class FluentValidationExtensions
{
    /// <summary>
    /// Validates that all elements in a collection are unique based on the default or provided key selector.
    /// No message is provided by default.
    /// </summary>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> MustBeUnique<T, TElement>(
        this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder,
        Func<TElement, object>? keySelector = null)
        where TElement : notnull
    {
        return ruleBuilder.Must(collection =>
        {
            if (collection == null)
            {
                return true;
            }

            var seenKeys = new HashSet<object>();
            foreach (var element in collection)
            {
                var key = keySelector != null ? keySelector(element) : element;
                if (!seenKeys.Add(key))
                {
                    return false;
                }
            }

            return true;
        });
    }

    /// <summary>
    /// Validates that the property is a valid URL.
    /// No message is provided by default.
    /// </summary>
    public static IRuleBuilderOptions<T, string> MustBeUrl<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(url =>
            !string.IsNullOrWhiteSpace(url) &&
            UrlRegex().IsMatch(url));
    }

    [GeneratedRegex(@"^https?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex UrlRegex();
}