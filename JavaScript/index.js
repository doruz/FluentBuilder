import UrlBuilder from './src/url-builder.js';

const examples = [
    getSimpleUrl(),
    getUrlWithPath(),
    getUrlWithCustomPort(),
    getUrlWithPathAndQueries()
];
examples.forEach(url => console.log(url));
console.log("");

function getSimpleUrl() {
    return UrlBuilder
        .https('www.travel.eu')
        .toString();
}

function getUrlWithCustomPort() {
    return UrlBuilder
        .https('www.travel.eu')
        .port(5001)
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
        .path(['countries', 'romania'])
        .path(['cities', 'iasi'])
        .query('type', 'nature')
        .query('lang', 'en')
        .toString();
}