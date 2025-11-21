namespace FluentBuilder.Url;

public interface IUrlBuilder : IUrlPath
{
    IUrlPath Port(ushort port);
}

public interface IUrlPath : IUrlQueries
{
    IUrlPath Path(params string[] segments);
}

public interface IUrlQueries : IUrl
{
    IUrlQueries Query(string key, string value);
}

public interface IUrl
{
    string ToString();
}