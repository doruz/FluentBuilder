using System.Web;

namespace FluentBuilder.Url;

public class UrlBuilder : IUrlBuilder
{
    private readonly string _address;
    private readonly List<string> _segments = [];
    private readonly SortedDictionary<string, string> _queries = [];

    private UrlBuilder(string protocol, string address)
    {
        protocol.EnsureIsNotEmpty(nameof(protocol));
        
        address
            .EnsureIsNotEmpty(nameof(address))
            .EnsureMatches(UrlRegex.Host, nameof(address));

        _address = $"{protocol}://{address.ToLower()}";
    }

    public static UrlBuilder Http(string host) => new("http", host);
    public static UrlBuilder Https(string host) => new("https", host);

    public ISegmentsBuilder WithSegment(string segment)
    {
        segment
            .EnsureIsNotEmpty(nameof(segment))
            .EnsureMatches(UrlRegex.SegmentAndQuery, nameof(segment));

        _segments.Add(segment);

        return this;
    }

    public IQueriesBuilder WithQuery(string key, string value)
    {
        key.EnsureIsNotEmpty(nameof(key));
        value.EnsureIsNotEmpty(nameof(value));

        _queries[key] = value;

        return this;
    }

    public string ToUrl()
    {
        return Join("?", GetFormattedSegments(), GetFormattedQueries());
    }

    private string GetFormattedSegments()
    {
        return Join("/", new[] { _address }.Concat(_segments));
    }

    private string GetFormattedQueries()
    {
        return Join("&", _queries.Select(q => $"{q.Key}={q.Value}"));
    }

    private static string Join(string separator, params IEnumerable<string> parts)
    {
        return string.Join(separator, parts.Where(part => string.IsNullOrWhiteSpace(part) is false));
    }
}