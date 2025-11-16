namespace FluentBuilder.Url;

public class UrlBuilder : ISegmentBuilder, IQueryStringBuilder, IBaseUrlBuilder
{
    private readonly string _baseAddress;
    private readonly List<string> _segments = [];
    private readonly SortedDictionary<string, string> _queryStrings = [];

    private UrlBuilder(string protocol, string address)
    {
        protocol.EnsureIsNotEmpty(nameof(protocol));
        address.EnsureIsNotEmpty(nameof(address));

        _baseAddress = $"{protocol}://{address.ToLower()}";
    }

    public static UrlBuilder Http(string address) => new("http", address);
    public static UrlBuilder Https(string address) => new("https", address);

    public ISegmentBuilder WithSegment(string segment)
    {
        _segments.Add(segment.EnsureIsNotEmpty(nameof(segment)));

        return this;
    }

    public IQueryStringBuilder WithQueryString(string key, string value)
    {
        key.EnsureIsNotEmpty(nameof(key));
        value.EnsureIsNotEmpty(nameof(value));

        _queryStrings[key] = $"{key}={value}";

        return this;
    }

    public string ToUrl()
    {
        return Join("?", GetFormattedSegments(), GetFormattedQueries());
    }

    private string GetFormattedSegments()
    {
        return Join("/", new[] { _baseAddress }.Concat(_segments));
    }

    private string GetFormattedQueries()
    {
        return Join("&", _queryStrings.Values);
    }

    private static string Join(string separator, params IEnumerable<string> parts)
    {
        return string.Join(separator, parts.Where(part => string.IsNullOrWhiteSpace(part) is false));
    }
}