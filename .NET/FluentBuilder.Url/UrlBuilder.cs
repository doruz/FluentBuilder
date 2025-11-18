namespace FluentBuilder.Url;

public sealed record UrlBuilder : IUrlBuilder
{
    private readonly string _protocol;
    private readonly string _host;
    
    private ushort? _port;
    private List<string> _segments = [];
    private SortedDictionary<string, string> _queries = [];

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

        return this with
        {
            _port = _protocol switch
            {
                UrlProtocols.Http when port != UrlPorts.Http => port,
                UrlProtocols.Https when port != UrlPorts.Https => port,
                _ => _port
            }
        };
    }

    public IUrlPath WithPath(params string[] segments)
    {
        foreach (var segment in segments)
        {
            segment
                .EnsureIsNotEmpty(nameof(segment))
                .EnsureMatches(UrlRegex.SegmentAndQuery, nameof(segment));
        }

        return this with
        {
            _segments = [.._segments, ..segments]
        };
    }

    public IUrlQueries WithQuery(string key, string value)
    {
        key.EnsureIsNotEmpty(nameof(key));
        value.EnsureIsNotEmpty(nameof(value));

        return this with
        {
            _queries = new SortedDictionary<string, string>(_queries)
            {
                [key] = value
            }
        };
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