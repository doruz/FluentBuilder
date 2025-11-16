namespace FluentBuilder.Url;

public interface ISegmentBuilder : IQueryStringBuilder, IBaseUrlBuilder
{
    ISegmentBuilder WithSegment(string segment);
}

public interface IQueryStringBuilder : IBaseUrlBuilder
{
    IQueryStringBuilder WithQueryString(string key, string value);
}

public interface IBaseUrlBuilder
{
    string ToUrl();
}