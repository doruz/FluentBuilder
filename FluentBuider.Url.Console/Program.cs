using FluentBuilder.Url;

Console.WriteLine(GetSimpleUrl());
Console.WriteLine(GetSimpleUrlWithCustomPort());
Console.WriteLine(GetUrlWithPath());
Console.WriteLine(GetUrlWithPathAndQueries());

string GetSimpleUrl() => UrlBuilder
    .Https("www.travel.eu")
    .ToString();

string GetSimpleUrlWithCustomPort() => UrlBuilder
    .Https("www.travel.eu")
    .OnPort(5001)
    .ToString();

string GetUrlWithPath() => UrlBuilder
    .Https("www.travel.eu")
    .WithSegment("countries")
    .WithSegment("romania")
    .ToString();

string GetUrlWithPathAndQueries() => UrlBuilder
    .Https("www.travel.eu")
    .WithSegment("countries")
    .WithSegment("romania")
    .WithQuery("type", "nature")
    .WithQuery("lang", "en")
    .ToString();