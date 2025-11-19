import UrlBuilder from './src/url-builder.js';

const examples = [
    getSimpleUrl(),
    getUrlWithPath(),
    getUrlWithCustomPort(),
];
examples.forEach(url => console.log(url));

function getSimpleUrl() {
    return UrlBuilder
        .https("www.travel.eu")
        .toString();
}

function getUrlWithCustomPort() {
    return UrlBuilder
        .https("www.travel.eu")
        .port(5001)
        .toString();
}

function getUrlWithPath() {
    return UrlBuilder
        .https("www.travel.eu")
        .path(["countries", "romania"])
        .path(["cities", "iasi"])
        .toString();
}