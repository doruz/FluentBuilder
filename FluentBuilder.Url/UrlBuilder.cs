namespace FluentBuilder.Url;

public class UrlBuilder : IUrlBuilder
{
    private readonly string _protocol;
    private readonly string _host;
    private ushort? _port;

    private readonly List<string> _segments = [];
    private readonly SortedDictionary<string, string> _queries = [];

    private UrlBuilder(string protocol, string host)
    {
        _protocol = protocol.EnsureIsNotEmpty(nameof(protocol));
        
        _host = host
            .EnsureIsNotEmpty(nameof(host))
            .EnsureMatches(UrlRegex.Host, nameof(host));
    }

    public static UrlBuilder Http(string host) => new(UrlProtocols.Http, host);
    public static UrlBuilder Https(string host) => new(UrlProtocols.Https, host);

    public IUrlPath OnPort(ushort port)
    {
        port.EnsurePortIsValid();

        _port = _protocol switch
        {
            UrlProtocols.Http when port != UrlPorts.Http => port,
            UrlProtocols.Https when port != UrlPorts.Https => port,
            _ => _port
        };

        return this;
    }

    public IUrlPath WithPath(params string[] segments)
    {
        foreach (var segment in segments)
        {
            WithPath(segment);
        }
        
        return this;
    }

    public IUrlPath WithPath(string segment)
    {
        segment
            .EnsureIsNotEmpty(nameof(segment))
            .EnsureMatches(UrlRegex.SegmentAndQuery, nameof(segment));

        _segments.Add(segment);

        return this;
    }

    public IUrlQueries WithQuery(string key, string value)
    {
        key.EnsureIsNotEmpty(nameof(key));
        value.EnsureIsNotEmpty(nameof(value));

        _queries[key] = value;

        return this;
    }

    public override string ToString()
    {
        return Join("?", GetFormattedSegments(), GetFormattedQueries());
    }

    private string GetFormattedSegments()
    {
        return Join("/", new[] { GetFormattedAddress() }.Concat(_segments));
    }

    private string GetFormattedAddress()
    {
        return _port is null
            ? $"{_protocol}://{_host.ToLower()}"
            : $"{_protocol}://{_host.ToLower()}:{_port}";
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