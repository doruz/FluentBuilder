import UrlBuilder from "./url-builder";

const examples = [
    getSimpleUrl(),
];
examples.forEach(url => console.log(url));

function getSimpleUrl() {
    return UrlBuilder
        .https('www.travel.eu')
        .toString();
}