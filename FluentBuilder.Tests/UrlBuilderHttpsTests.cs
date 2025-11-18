using FluentBuilder.Url;

namespace FluentBuilder.Tests;

public class UrlBuilderHttpsTests : UrlBuilderTests
{
    protected override Func<string, UrlBuilder> Host => UrlBuilder.Https;
    protected override ushort DefaultPort => 443;

    protected override string GetExpected(string url) => $"https://{url}";
}