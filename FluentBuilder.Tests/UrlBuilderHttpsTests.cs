using FluentBuilder.Url;

namespace FluentBuilder.Tests;

public class UrlBuilderHttpsTests
{
    [Fact]
    public void When_UsingNullOrEmptyAddress_Should_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => UrlBuilder.Https(null!));
        Assert.Throws<ArgumentException>(() => UrlBuilder.Https(string.Empty));
    }

    [Fact]
    public void When_UsingSimpleAddress_Should_ReturnCorrectUrl()
    {
        // Arrange
        const string expected = "https://www.travel.eu";

        // Act
        var actual = UrlBuilder.Https("www.travel.eu").ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingNullOrEmptySegment_Should_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => UrlBuilder
            .Https("www.travel.eu")
            .WithSegment(null!)
        );

        Assert.Throws<ArgumentException>(() => UrlBuilder
            .Https("www.travel.eu")
            .WithSegment(string.Empty)
        );
    }

    [Fact]
    public void When_AddingSegments_Should_ThrowException()
    {
        // Arrange
        const string expected = "https://www.travel.eu/countries/romania";

        // Act
        var actual = UrlBuilder
            .Https("www.travel.eu")
            .WithSegment("countries")
            .WithSegment("romania")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }
}

public class UrlBuilderHttpTests
{
    [Fact]
    public void When_UsingNullOrEmptyAddress_Should_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => UrlBuilder.Http(null!));
        Assert.Throws<ArgumentException>(() => UrlBuilder.Http(string.Empty));
    }

    [Fact]
    public void When_UsingSimpleAddress_Should_ReturnCorrectUrl()
    {
        // Arrange
        const string expected = "http://www.travel.eu";

        // Act
        var actual = UrlBuilder.Http("www.travel.eu").ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingNullOrEmptySegment_Should_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => UrlBuilder
            .Http("www.travel.eu")
            .WithSegment(null!)
        );

        Assert.Throws<ArgumentException>(() => UrlBuilder
            .Http("www.travel.eu")
            .WithSegment(string.Empty)
        );
    }


    [Fact]
    public void When_AddingSegments_Should_ThrowException()
    {
        // Arrange
        const string expected = "http://www.travel.eu/countries/romania";

        // Act
        var actual = UrlBuilder
            .Http("www.travel.eu")
            .WithSegment("countries")
            .WithSegment("romania")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }
}