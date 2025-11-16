using FluentBuilder.Url;

namespace FluentBuilder.Tests;

public class UrlBuilderHttpsTests
{
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
    public void When_UsingInvalidAddress_Should_ThrowException(string urlAddress)
    {
        Assert.Throws<ArgumentException>(() => UrlBuilder.Https(urlAddress));
    }

    [Fact]
    public void When_UsingValidAddress_Should_BuildCorrectUrl()
    {
        // Arrange
        const string expected = "https://www.travel.eu";

        // Act
        var actual = UrlBuilder.Https("www.travel.eu").ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(InvalidValues))]
    public void When_AddingInvalidSegment_Should_ThrowException(string urlSegment)
    {
        Assert.Throws<ArgumentException>(() => UrlBuilder
            .Https("www.travel.eu")
            .WithSegment(urlSegment)
        );
    }

    [Fact]
    public void When_AddingValidSegments_Should_BuildCorrectUrl()
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

    [Theory]
    [MemberData(nameof(InvalidQueries))]
    public void When_AddingInvalidQuery_Should_ThrowException(string key, string value)
    {
        Assert.Throws<ArgumentException>(() => UrlBuilder
            .Https("www.travel.eu")
            .WithQueryString(key, value)
        );
    }

    [Fact]
    public void When_AddingValidQuery_Should_BuildCorrectUrl()
    {
        // Arrange
        const string expected = "http://www.travel.eu?lang=en";

        // Act
        var actual = UrlBuilder
            .Http("www.travel.eu")
            .WithQueryString("lang", "en")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingSameQueryKey_Should_UseLastProvidedValue()
    {
        // Arrange
        const string expected = "http://www.travel.eu?lang=ro";

        // Act
        var actual = UrlBuilder
            .Http("www.travel.eu")
            .WithQueryString("lang", "en")
            .WithQueryString("lang", "ro")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }


    [Fact]
    public void When_AddingMultipleQueries_Should_OrderThemAscendingByKey()
    {
        // Arrange
        const string expected = "http://www.travel.eu?lang=en&type=nature";

        // Act
        var actual = UrlBuilder
            .Http("www.travel.eu")
            .WithQueryString("type", "nature")
            .WithQueryString("lang", "en")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingSegmentsAndQueries_Should_BuildCorrectUrl()
    {
        // Arrange
        const string expected = "http://www.travel.eu/countries/romania?lang=en&type=nature";

        // Act
        var actual = UrlBuilder
            .Http("www.travel.eu")
            .WithSegment("countries").WithSegment("romania")
            .WithQueryString("type", "nature")
            .WithQueryString("lang", "en")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingSegmentsAndQueries_Should_BuildCaseSensitiveUrl()
    {
        // Arrange
        const string expected = "http://www.travel.eu/Countries/RomaniA?Lang=EN&TypE=NaturE";

        // Act
        var actual = UrlBuilder
            .Http("Www.TRAVEL.eU")
            .WithSegment("Countries").WithSegment("RomaniA")
            .WithQueryString("TypE", "NaturE")
            .WithQueryString("Lang", "EN")
            .ToUrl();

        // Assert
        Assert.Equal(expected, actual);
    }
}