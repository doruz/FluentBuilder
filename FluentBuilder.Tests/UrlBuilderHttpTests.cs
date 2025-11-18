using FluentBuilder.Url;

namespace FluentBuilder.Tests;

public class UrlBuilderHttpTests : UrlBuilderTests
{
    protected override Func<string, UrlBuilder> Host => UrlBuilder.Http;
    protected override ushort DefaultPort => 80;

    protected override string GetExpected(string url) => $"http://{url}";
}