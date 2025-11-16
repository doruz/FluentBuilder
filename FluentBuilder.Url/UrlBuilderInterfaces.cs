namespace FluentBuilder.Url;

public interface IUrlBuilder : ISegmentBuilder;

public interface ISegmentBuilder : IQueryBuilder
{
    ISegmentBuilder WithSegment(string segment);
}

public interface IQueryBuilder : IBaseUrlBuilder
{
    IQueryBuilder WithQuery(string key, string value);
}

public interface IBaseUrlBuilder
{
    string ToUrl();
}