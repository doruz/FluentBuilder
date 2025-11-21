using FluentBuilder.Url;

Console.WriteLine(GetSimpleUrl());
Console.WriteLine(GetSimpleUrlWithCustomPort());
Console.WriteLine(GetUrlWithPath());
Console.WriteLine(GetUrlWithPathAndQueries());
UsingSameBuilderInstance();

string GetSimpleUrl() => UrlBuilder
    .Https("www.travel.eu")
    .ToString();

string GetSimpleUrlWithCustomPort() => UrlBuilder
    .Https("www.travel.eu")
    .Port(5001)
    .ToString();

string GetUrlWithPath() => UrlBuilder
    .Https("www.travel.eu")
    .Path("countries", "romania")
    .ToString();

string GetUrlWithPathAndQueries() => UrlBuilder
    .Https("www.travel.eu")
    .Path("countries", "romania")
    .Query("type", "nature")
    .Query("lang", "en")
    .ToString();

void UsingSameBuilderInstance()
{
    Console.WriteLine();

    var builder = UrlBuilder
        .Https("www.travel.eu")
        .Path("countries", "romania");

    Console.WriteLine(builder
        .Path("cities", "iasi")
        .ToString());

    Console.WriteLine(builder
        .Query("type", "nature")
        .Query("lang", "en")
        .ToString()
    );
}