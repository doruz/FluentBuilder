# FluentBuilder

An implementation of the fluent builder design pattern for creating urls.

```csharp
UrlBuilder.Http("www.travel.eu")
    .WithSegment("countries").WithSegment("romania")
    .WithQuery("type", "nature")
    .WithQuery("lang", "en")
    .ToUrl();

// http://www.travel.eu/countries/romania?lang=en&type=nature
```

```csharp
UrlBuilder.Https("www.travel.eu")
    .WithSegment("countries").WithSegment("romania")
    .WithQuery("type", "nature")
    .WithQuery("lang", "en")
    .ToUrl();

// https://www.travel.eu/countries/romania?lang=en&type=nature
```
