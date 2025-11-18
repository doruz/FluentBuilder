namespace FluentBuilder.Url.Tests;

public abstract class UrlBuilderTests
{
    protected abstract Func <string, UrlBuilder> Host { get; }

    protected abstract ushort DefaultPort { get; }

    protected abstract string GetExpected(string url);

    public static IEnumerable<object?[]> EmptyValues => new List<string?[]>
    {
        new string?[] { null },
        new[] { "" },
        new[] { "    " },
    };

    public static IEnumerable<object?[]> InvalidQueries => new List<string?[]>
    {
        new[] { null, "en" },
        new[] { "", "en" },
        new[] { "    ", "en" },

        new[] { "lang", null },
        new[] { "lang", "" },
        new[] { "lang", "    " },
    };

    [Theory]
    [MemberData(nameof(EmptyValues))]
    public void When_UsingEmptyAddress_Should_ThrowException(string host)
    {
        Assert.Throws<ArgumentException>(() => Host(host));
    }

    [Theory]
    [InlineData("-bad.com")]
    [InlineData("bad-.com")]
    [InlineData("example")]
    [InlineData("travel more.eu")]
    public void When_UsingInvalidAddress_Should_ThrowException(string host)
    {
        Assert.Throws<ArgumentException>(() => Host(host));
    }

    [Theory]
    [InlineData("travel.eu")]
    [InlineData("www.travel.eu")]
    [InlineData("api.travel.eu")]
    [InlineData("api-travel.eu")]
    [InlineData("api2.travel.eu")]
    [InlineData("api-2.travel.eu")]
    public void When_UsingValidAddress_Should_BuildCorrectUrl(string host)
    {
        // Arrange
        string expected = GetExpected(host);

        // Act
        var actual = Host(host).ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_UsingValidAddressWithDefaultPort_Should_BuildCorrectUrlWithoutPort()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu");

        // Act
        var actual = Host("www.travel.eu")
            .OnPort(DefaultPort)
            .ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_UsingValidAddressWithCustomPort_Should_BuildCorrectUrlWithPort()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu:5001");

        // Act
        var actual = Host("www.travel.eu")
            .OnPort(5001)
            .ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(EmptyValues))]
    public void When_AddingInvalidPath_Should_ThrowException(string path)
    {
        Assert.Throws<ArgumentException>(() => Host("www.travel.eu").WithPath([path]));
        Assert.Throws<ArgumentException>(() => Host("www.travel.eu").WithPath("countries", path));
    }

    [Fact]
    public void When_AddingValidPaths_Should_BuildCorrectUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu/countries/romania/cities/iasi");

        // Act
        var actual = Host("www.travel.eu")
            .WithPath("countries", "romania")
            .WithPath("cities", "iasi")
            .ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingValidPathsWithSpecialCharacters_Should_BuildCorrectUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu/~a-1_c.2");

        // Act
        var actual = Host("www.travel.eu")
            .WithPath("~a-1_c.2")
            .ToString();

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
            .ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingValidQueryWithSpecialCharacters_Should_BuildCorrectUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu?~a-1_c.2=~1-a_2.c");

        // Act
        var actual = Host("www.travel.eu")
            .WithQuery("~a-1_c.2", "~1-a_2.c")
            .ToString();

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
            .ToString();

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
            .ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingPathsAndQueries_Should_BuildCorrectUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu/countries/romania?lang=en&type=nature");

        // Act
        var actual = Host("www.travel.eu")
            .WithPath("countries", "romania")
            .WithQuery("type", "nature")
            .WithQuery("lang", "en")
            .ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingCustomPortAndPathsAndQueries_Should_BuildCorrectUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu:5001/countries/romania?lang=en&type=nature");

        // Act
        var actual = Host("www.travel.eu")
            .OnPort(5001)
            .WithPath("countries", "romania")
            .WithQuery("type", "nature")
            .WithQuery("lang", "en")
            .ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_AddingPathsAndQueries_Should_BuildCaseSensitiveUrl()
    {
        // Arrange
        string expected = GetExpected("www.travel.eu/Countries/RomaniA?Lang=EN&TypE=NaturE");

        // Act
        var actual = Host("Www.TRAVEL.eU")
            .WithPath("Countries").WithPath("RomaniA")
            .WithQuery("TypE", "NaturE")
            .WithQuery("Lang", "EN")
            .ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void When_UsingSameBuilderInstance_Should_BeImmutable()
    {
        // Arrange
        var builder = Host("www.travel.eu").WithPath("countries", "romania");

        // Assert #1
        Assert.Equal(
            GetExpected("www.travel.eu/countries/romania/cities/iasi"),
            builder.WithPath("cities", "iasi").ToString()
        );

        // Assert #2
        Assert.Equal(
            GetExpected("www.travel.eu/countries/romania?lang=en"),
            builder.WithQuery("lang", "en").ToString()
        );
    }
}