# Fluent Builder in C#

An example of the fluent builder design pattern for creating urls.

```csharp
// https://www.travel.eu/countries/romania

UrlBuilder
    .Https("www.travel.eu")
    .Path("countries", "romania")
    .ToString();
```

```csharp
// https://www.travel.eu:5001/countries/romania

UrlBuilder
    .Https("www.travel.eu")
    .Port(5001)
    .Path("countries", "romania")
    .ToString();
```

```csharp
// https://www.travel.eu/countries/romania?lang=en&type=nature

UrlBuilder
    .Https("www.travel.eu")
    .Path("countries", "romania")
    .Query("lang", "en")
    .Query("type", "nature")
    .ToString();
```