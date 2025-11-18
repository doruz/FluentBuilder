# FluentBuilder

An implementation of the fluent builder design pattern for creating urls.


```csharp
// https://www.travel.eu/countries/romania

UrlBuilder.Https("www.travel.eu")
    .WithSegment("countries")
    .WithSegment("romania")
    .ToUrl();
```

```csharp
// https://www.travel.eu:5001/countries/romania

UrlBuilder.Https("www.travel.eu")
    .OnPort(5001)
    .WithSegment("countries")
    .WithSegment("romania")
    .ToUrl();
```

```csharp
// https://www.travel.eu/countries/romania?lang=en&type=nature

UrlBuilder.Https("www.travel.eu")
    .WithSegment("countries")
    .WithSegment("romania")
    .WithQuery("lang", "en")
    .WithQuery("type", "nature")
    .ToUrl();
```
