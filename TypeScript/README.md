# Fluent Builder in TypeScript

An example of the fluent builder design pattern for creating urls.

```ts
// https://www.travel.eu/countries/romania

UrlBuilder
    .https("www.travel.eu")
    .path(["countries", "romania"])
    .toString();
```

```ts
// https://www.travel.eu:5001/countries/romania

UrlBuilder
    .https("www.travel.eu")
    .port(5001)
    .path(["countries", "romania"])
    .toString();
```

```ts
// https://www.travel.eu/countries/romania?lang=en&type=nature

UrlBuilder
    .https("www.travel.eu")
    .path(["countries", "romania"])
    .query('lang', 'en')
    .query('type', 'nature')
    .toString();
```