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
    .OnPort(5001)
    .ToString();

string GetUrlWithPath() => UrlBuilder
    .Https("www.travel.eu")
    .WithPath("countries")
    .WithPath("romania")
    .ToString();

string GetUrlWithPathAndQueries() => UrlBuilder
    .Https("www.travel.eu")
    .WithPath("countries", "romania")
    .WithQuery("type", "nature")
    .WithQuery("lang", "en")
    .ToString();

void UsingSameBuilderInstance()
{
    Console.WriteLine();

    var builder = UrlBuilder
        .Https("www.travel.eu")
        .WithPath("countries", "romania");

    Console.WriteLine(builder
        .WithPath("cities", "iasi")
        .ToString());

    Console.WriteLine(builder
        .WithQuery("type", "nature")
        .WithQuery("lang", "en")
        .ToString()
    );
}