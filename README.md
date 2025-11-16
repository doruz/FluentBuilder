# FluentBuilder

An implementation of the fluent builder design pattern for creating urls.

```csharp
UrlBuilder.Http("www.travel.eu")
    .WithSegment("countries")
    .WithSegment("romania")
    .WithQuery("lang", "en")
    .WithQuery("type", "nature")
    .ToUrl();

// http://www.travel.eu/countries/romania?lang=en&type=nature
```

```csharp
UrlBuilder.Https("www.travel.eu")
    .WithSegment("countries")
    .WithSegment("romania")
    .WithQuery("lang", "en")
    .WithQuery("type", "nature")
    .ToUrl();

// https://www.travel.eu/countries/romania?lang=en&type=nature
```
