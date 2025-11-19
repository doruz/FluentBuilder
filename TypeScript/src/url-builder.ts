import { UrlProtocols } from "./url-constants";
import UrlValues from "./url-values";

export default class UrlBuilder {
    private constructor(private readonly values: UrlValues) {
    }

    /**
     * Creates a new instance of http url builder.
     * @param {string} host 
     */
    public static http = (host: string) => new UrlBuilder(new UrlValues(UrlProtocols.http, host));

    /**
     * Creates a new instance of https url builder.
     * @param {string} host 
     */
    public static https = (host: string) => new UrlBuilder(new UrlValues(UrlProtocols.https, host));

    /**
     * Build the full url with the provided values.
     */
    public toString(): string {
        const baseUrl = `${this.values.protocol}://${this.values.host}`;
        return baseUrl;
    }
}