import UrlBuilder from './src/url-builder.js';

const examples = [
    getSimpleUrl(),
    getUrlWithPath(),
    getUrlWithPathAndQueries(),
    "",
    getUrlWithCustomPort(),
    getUrlWithCustomPortAndPathAndQueries(),
    "",
    ...usingSameBuilderInstance(),
    ""
];
examples.forEach(url => console.log(url));

function getSimpleUrl() {
    return UrlBuilder
        .https('www.travel.eu')
        .toString();
}

function getUrlWithPath() {
    return UrlBuilder
        .https('www.travel.eu')
        .path(['countries', 'romania'])
        .path(['cities', 'iasi'])
        .toString();
}

function getUrlWithPathAndQueries() {
    return UrlBuilder
        .https('www.travel.eu')
        .path(['countries', 'romania', 'cities', 'iasi'])
        .query('type', 'nature')
        .query('lang', 'en')
        .toString();
}

function getUrlWithCustomPort() {
    return UrlBuilder
        .https('www.travel.eu')
        .port(5001)
        .toString();
}

function getUrlWithCustomPortAndPathAndQueries() {
    return UrlBuilder
        .https('www.travel.eu')
        .port(5001)
        .path(['countries', 'romania'])
        .query('lang', 'en')
        .toString();
}

function usingSameBuilderInstance() {
    const builder = UrlBuilder
        .https("www.travel.eu")
        .path(["countries", "romania"]);

    return [
        builder
            .query('type', 'nature')
            .query('lang', 'ro')
            .toString(),

        builder
            .path(['cities', 'iasi'])
            .toString(),

        builder
            .query('type', 'nature')
            .toString()
    ];
}