# FluentBuilder

An implementation of the fluent builder design pattern for creating urls.


```csharp
// https://www.travel.eu/countries/romania

UrlBuilder.Https("www.travel.eu")
    .WithPath("countries")
    .WithPath("romania")
    .ToString();

UrlBuilder.Https("www.travel.eu")
    .WithPath("countries", "romania")
    .ToString();
```

```csharp
// https://www.travel.eu:5001/countries/romania

UrlBuilder.Https("www.travel.eu")
    .OnPort(5001)
    .WithPath("countries", "romania")
    .ToString();
```

```csharp
// https://www.travel.eu/countries/romania?lang=en&type=nature

UrlBuilder.Https("www.travel.eu")
    .WithPath("countries", "romania")
    .WithQuery("lang", "en")
    .WithQuery("type", "nature")
    .ToString();
```
