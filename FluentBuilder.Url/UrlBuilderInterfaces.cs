namespace FluentBuilder.Url;

public interface IUrlBuilder : IUrlPath
{
    IUrlPath OnPort(ushort port);
}

public interface IUrlPath : IUrlQueries
{
    IUrlPath WithPath(params string[] segments);

    IUrlPath WithPath(string segment);
}

public interface IUrlQueries : IUrl
{
    IUrlQueries WithQuery(string key, string value);
}

public interface IUrl
{
    string ToString();
}