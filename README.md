# FluentBuilder


Examples of the fluent builder design pattern for creating urls.

### C#
```csharp
// https://www.travel.eu/countries/romania?lang=en&type=nature

UrlBuilder
    .Https("www.travel.eu")
    .Path("countries", "romania")
    .Query("lang", "en")
    .Query("type", "nature")
    .ToString();
```

### JavaScript & TypeScript
```js
// https://www.travel.eu/countries/romania?lang=en&type=nature

UrlBuilder
    .https("www.travel.eu")
    .path(["countries", "romania"])
    .query('lang', 'en')
    .query('type', 'nature')
    .toString();
```