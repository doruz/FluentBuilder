using FluentBuilder.Url;

namespace FluentBuilder.Tests;

public abstract class UrlBuilderTests
{
    protected abstract Func <string, UrlBuilder> Host { get; }

    protected abstract string GetExpected(string url);

    public static IEnumerable<string?[]> InvalidValues => new List<string?[]>
    {
        new string?[] { null },
        new[] { "" },
        new[] { "    " },
    };

    public static IEnumerable<string?[]> InvalidQueries => new List<string?[]>
    {
        new[] { null, "en" },
        new[] { "", "en" },
        new[] { "    ", "en" },

        new[] { "lang", null },
        new[] { "lang", "" },
        new[] { "lang", "    " },
    };

    [Theory]
    [MemberData(nameof(InvalidValues))]
    public void When_UsingInvalidAddress_Should_ThrowException(string urlHost)
    {
        Assert.Throws<ArgumentException>(() => Host(urlHost));
    }

    [Fact]
    public void When_UsingValidAddress_Should_BuildCorrectUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu");

        // Act
        var actual = Host("www.travel.eu").ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(InvalidValues))]
    public void When_AddingInvalidSegment_Should_ThrowException(string urlSegment)
    {
        Assert.Throws<ArgumentException>(() => Host("www.travel.eu").WithSegment(urlSegment));
    }

    [Fact]
    public void When_AddingValidSegments_Should_BuildCorrectUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu/countries/romania");

        // Act
        var actual = Host("www.travel.eu")
            .WithSegment("countries")
            .WithSegment("romania")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(InvalidQueries))]
    public void When_AddingInvalidQuery_Should_ThrowException(string key, string value)
    {
        Assert.Throws<ArgumentException>(() => Host("www.travel.eu").WithQuery(key, value));
    }

    [Fact]
    public void When_AddingValidQuery_Should_BuildCorrectUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu?lang=en");

        // Act
        var actual = Host("www.travel.eu")
            .WithQuery("lang", "en")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingSameQueryKey_Should_UseLastProvidedValue()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu?lang=ro");

        // Act
        var actual = Host("www.travel.eu")
            .WithQuery("lang", "en")
            .WithQuery("lang", "ro")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }


    [Fact]
    public void When_AddingMultipleQueries_Should_OrderThemAscendingByKey()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu?lang=en&type=nature");

        // Act
        var actual = Host("www.travel.eu")
            .WithQuery("type", "nature")
            .WithQuery("lang", "en")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingSegmentsAndQueries_Should_BuildCorrectUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu/countries/romania?lang=en&type=nature");

        // Act
        var actual = Host("www.travel.eu")
            .WithSegment("countries").WithSegment("romania")
            .WithQuery("type", "nature")
            .WithQuery("lang", "en")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingSegmentsAndQueries_Should_BuildCaseSensitiveUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu/Countries/RomaniA?Lang=EN&TypE=NaturE");

        // Act
        var actual = Host("Www.TRAVEL.eU")
            .WithSegment("Countries").WithSegment("RomaniA")
            .WithQuery("TypE", "NaturE")
            .WithQuery("Lang", "EN")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }
}