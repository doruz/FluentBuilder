import { UrlProtocols } from './url-constants.js';
import UrlValues from './url-values.js';

export default class UrlBuilder {
    #values;

    constructor(params) {
        this.#values = params;
    }

    /**
     * Creates a new instance of http url builder
     * @param {string} host 
     * @returns {UrlBuilder} urlBuilder
     */
    static http = (host) => new UrlBuilder(new UrlValues(UrlProtocols.http, host));

    /**
     * Creates a new instance of https url builder
     * @param {string} host 
     * @returns {UrlBuilder} urlBuilder
     */
    static https = (host) => new UrlBuilder(new UrlValues(UrlProtocols.https, host));

    /**
     * Set port in case it is different than default (http: 80, https:443).
     * @param {number} port
     * @returns 
     */
    port = (port) => new UrlBuilder(this.#values.updatePort(port));

    path = (pathSegments) => new UrlBuilder(this.#values.updatePath(pathSegments));

    query = (key, value) => new UrlBuilder(this.#values.updateQuery(key, value));

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

        for (const key in this.#values.queries) {
            queries.push(`${key}=${this.#values.queries[key]}`);
        }

        return queries.join('&');
    }
}