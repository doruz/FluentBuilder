import { UrlProtocols } from './url-constants.ts';
import UrlValues from './url-values.ts';

export default class UrlBuilder {
    private constructor(private readonly values: UrlValues) { }

    /**
     * Creates a new instance of http url builder.
     * @param {string} host 
     */
    public static http = (host: any) => new UrlBuilder(new UrlValues(UrlProtocols.http, host));

    /**
     * Creates a new instance of https url builder.
     * @param {string} host 
     */
    public static https = (host: string) => new UrlBuilder(new UrlValues(UrlProtocols.https, host));

    /**
     * Sets url port.
     * Port is configured only if it is different than implicit values (http:80, https:443).
     * @param {number} port
     */
    public port = (port: number) => new UrlBuilder(this.values.updatePort(port));

    /**
   * Sets url paths segments.
   * @param {string[]} segments
   */
    public path = (segments: string[]) => new UrlBuilder(this.values.updatePath(segments));

    /**
     * Sets url query parameter.
     * @param {string} key 
     * @param {string} value 
     */
    public query = (key: string, value: string) => new UrlBuilder(this.values.updateQuery(key, value));

    /**
     * Build the full url with the provided values.
     */
    public toString(): string {
        const addressAndPath = this.getFormattedAddressAndPath();
        const queries = this.getFormattedQueryParams();

        if (queries) {
            return `${addressAndPath}?${queries}`;
        }

        return addressAndPath;
    }

    private getFormattedAddressAndPath(): string {
        return [this.getFormattedAddress(), ...this.values.pathSegments].join('/');
    }

    private getFormattedAddress(): string {
        return this.values.port === null
            ? `${this.values.protocol}://${this.values.host}`
            : `${this.values.protocol}://${this.values.host}:${this.values.port}`;
    }

    private getFormattedQueryParams(): string {
        const queries: string[] = [];

        for (const [key, value] of this.values.queries.entries()) {
            queries.push(`${key}=${value}`);
        }

        return queries.join('&');
    }
}