import { UrlProtocols } from './url-constants.js';
import UrlValues from './url-values.js';

export default class UrlBuilder {
    #values;

    constructor(values) {
        this.#values = values;
    }

    /**
     * Creates a new instance of http url builder.
     * @param {string} host 
     */
    static http = (host) => new UrlBuilder(new UrlValues(UrlProtocols.http, host));

    /**
     * Creates a new instance of https url builder.
     * @param {string} host 
     */
    static https = (host) => new UrlBuilder(new UrlValues(UrlProtocols.https, host));

    /**
     * Sets url port.
     * Port is configured only if it is different than implicit values (http:80, https:443).
     * @param {number} port
     */
    port = (port) => new UrlBuilder(this.#values.updatePort(port));

    /**
     * Sets url paths segments.
     * @param {string[]} segments
     */
    path = (segments) => new UrlBuilder(this.#values.updatePath(segments));

    /**
     * Sets url query parameter.
     * @param {string} key 
     * @param {string} value 
     */
    query = (key, value) => new UrlBuilder(this.#values.updateQuery(key, value));

    /**
     * Build the full url with the provided values.
     */
    toString() {
        const addressAndPath = this.#getFormattedAddressAndPath();
        const queries = this.#getFormattedQueryParams();

        if (queries) {
            return `${addressAndPath}?${queries}`;
        }

        return addressAndPath;
    }

    #getFormattedAddressAndPath() {
        return [this.#getFormattedAddress(), ...this.#values.pathSegments].join('/');
    }

    #getFormattedAddress() {
        return this.#values.port === null
            ? `${this.#values.protocol}://${this.#values.host}`
            : `${this.#values.protocol}://${this.#values.host}:${this.#values.port}`;
    }

    #getFormattedQueryParams() {
        const queries = [];

        for (let key in this.#values.queries) {
            queries.push(`${key}=${this.#values.queries[key]}`);
        }

        return queries.join('&');
    }
}