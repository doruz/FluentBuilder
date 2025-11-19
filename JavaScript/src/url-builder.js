import { UrlPorts, UrlProtocols } from './url-constants.js';
import UrlValidations from './url-validations.js';

export default class UrlBuilder {
    #protocol;
    #host;
    #port = null;
    #pathSegments = [];

    /**
     * Creates a new instance of url builder.
     * @param {string} protocol 
     * @param {string} host
     */
    constructor(protocol, host) {
        this.#protocol = protocol;
        this.#host = host;
    }

    /**
     * Creates a new instance of http url builder
     * @param {string} host 
     * @returns {UrlBuilder} urlBuilder
     */
    static http = (host) => new UrlBuilder(UrlProtocols.http, host);

    /**
     * Creates a new instance of https url builder
     * @param {string} host 
     * @returns {UrlBuilder} urlBuilder
     */
    static https = (host) => new UrlBuilder(UrlProtocols.https, host);

    /**
     * Set port in case it is different than default (http: 80, https:443).
     * @param {number} port
     * @returns 
     */
    port(port) {
        UrlPorts.ensureIsValid(port);

        this.#port = null;

        if (this.#protocol === UrlProtocols.http && port == UrlPorts.http) {
            return this;
        }

        if (this.#protocol === UrlProtocols.https && port == UrlPorts.https) {
            return this;
        }

        this.#port = port;

        return this;
    }

    /**
     * 
     * @param {string[]} path 
     * @returns 
     */
    path(pathSegments) {
        pathSegments.forEach((segment, index, _) => {
            UrlValidations.ensureIsNotEmpty(segment, `pathSegments[${index}]`);
        });

        this.#pathSegments = [...this.#pathSegments, ...pathSegments];

        return this;
    }

    toString() {
        return this.#getFormmattedSegments();
    }

    #getFormmattedSegments() {
        return [this.#getFormattedAddress(), ...this.#pathSegments].join('/');
    }

    #getFormattedAddress() {
        UrlValidations.ensureIsNotEmpty(this.#host, 'host');

        return this.#port === null
            ? `${this.#protocol}://${this.#host}`
            : `${this.#protocol}://${this.#host}:${this.#port}`;
    }
}