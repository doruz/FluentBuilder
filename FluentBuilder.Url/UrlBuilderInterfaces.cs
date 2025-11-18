namespace FluentBuilder.Url;

public interface IUrlBuilder : ISegmentsBuilder
{
    ISegmentsBuilder OnPort(ushort port);
}

public interface ISegmentsBuilder : IQueriesBuilder
{
    ISegmentsBuilder WithSegment(string segment);
}

public interface IQueriesBuilder : IBaseUrlBuilder
{
    IQueriesBuilder WithQuery(string key, string value);
}

public interface IBaseUrlBuilder
{
    string ToString();
}