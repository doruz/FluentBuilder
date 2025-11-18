using System.Text.RegularExpressions;

namespace FluentBuilder.Url;

internal static class UrlRegex
{
    public const string Host = "^(?=.{1,253}$)(?!-)(?:[a-zA-Z0-9-]{1,63}(?<!-)\\.)+[a-zA-Z]{2,63}$";
    public const string SegmentAndQuery = @"^(?:[A-Za-z0-9\-\._~ %!$&'()*+,;=:@/]*)$";

    internal static string EnsureMatches(this string value, string pattern, string parameterName)
    {
        if (Regex.IsMatch(value, pattern))
        {
            return value;
        }

        throw new ArgumentException($"'{value}' doesn't match pattern", parameterName);
    }
}