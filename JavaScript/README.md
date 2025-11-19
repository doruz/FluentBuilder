# Fluent Builder in JavaScript

An example of the fluent builder design pattern for creating urls.

```js
// https://www.travel.eu/countries/romania

UrlBuilder
    .https("www.travel.eu")
    .path(["countries", "romania"])
    .toString();
```

```js
// https://www.travel.eu:5001/countries/romania

UrlBuilder
    .https("www.travel.eu")
    .port(5001)
    .path(["countries", "romania"])
    .toString();
```

```js
// https://www.travel.eu/countries/romania?lang=en&type=nature

UrlBuilder
    .https("www.travel.eu")
    .path(["countries", "romania"])
    .query('lang', 'en')
    .query('type', 'nature')
    .toString();
```

```js
// https://www.travel.eu:5001/countries/romania?lang=en&type=nature

UrlBuilder
    .https("www.travel.eu")
    .port(5001)
    .path(["countries", "romania"])
    .query('lang', 'en')
    .query('type', 'nature')
    .toString();
```