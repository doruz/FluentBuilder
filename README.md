# FluentBuilder

An implementation of the fluent builder design pattern for creating urls.

```csharp
// http://www.travel.eu/countries/romania?lang=en&type=nature
UrlBuilder.Http("www.travel.eu")
    .WithSegment("countries").WithSegment("romania")
    .WithQuery("type", "nature")
    .WithQuery("lang", "en")
    .ToUrl();
```

```csharp
// https://www.travel.eu/countries/romania?lang=en&type=nature
UrlBuilder.Https("www.travel.eu")
    .WithSegment("countries").WithSegment("romania")
    .WithQuery("type", "nature")
    .WithQuery("lang", "en")
    .ToUrl();
```