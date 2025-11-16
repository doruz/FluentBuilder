using EnsureThat;

namespace FluentBuilder.Url;

public class UrlBuilder : ISegmentBuilder, IQueryStringBuilder, IBaseUrlBuilder
{
    private readonly string _baseAddress;
    private readonly List<string> _segments = [];
    private readonly SortedDictionary<string, string> _queryStrings = [];

    private UrlBuilder(string protocol, string address)
    {
        Ensure.String.IsNotNullOrEmpty(protocol, nameof(protocol));
        Ensure.String.IsNotNullOrEmpty(address, nameof(address));

        _baseAddress = $"{protocol}://{address}";
    }

    public static UrlBuilder Http(string address) => new("http", address);
    public static UrlBuilder Https(string address) => new("https", address);

    public ISegmentBuilder WithSegment(string segment)
    {
        Ensure.String.IsNotNullOrEmpty(segment, nameof(segment));

        _segments.Add(segment);

        return this;
    }

    public IQueryStringBuilder WithQueryString(Action<QueryString> initializer)
    {
        var query = new QueryString();
        initializer(query);

        if (query.IsInitialized)
        {
            _queryStrings[query.Key.ToLower()] = query.ToString();
        }

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