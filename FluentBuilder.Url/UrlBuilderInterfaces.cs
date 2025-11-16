namespace FluentBuilder.Url
{
    public interface ISegmentBuilder : IQueryStringBuilder, IBaseUrlBuilder
    {
        ISegmentBuilder WithSegment(string segment);
    }

    public interface IQueryStringBuilder : IBaseUrlBuilder
    {
        IQueryStringBuilder WithQueryString(Action<QueryString> initializer);
    }

    public interface IBaseUrlBuilder
    {
        string ToUrl();
    }
}
