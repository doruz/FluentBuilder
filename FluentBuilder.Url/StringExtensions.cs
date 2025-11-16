namespace FluentBuilder.Url;

internal static class StringExtensions
{
    internal static string EnsureIsNotEmpty(this string? value, string parameterName)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", parameterName);
        }

        return value;
    }
}