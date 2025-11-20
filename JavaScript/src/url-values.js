import { UrlPorts, UrlProtocols } from './url-constants.js';
import UrlStrings from './url-strings.js';

export default class UrlValues {
    protocol;
    host;
    port = null;
    pathSegments = [];
    queries = {};

    constructor(protocol, host) {
        this.protocol = UrlStrings.ensureIsNotEmpty(protocol, 'protocol');
        this.host = UrlStrings.ensureIsNotEmpty(host, 'host');
    }

    updatePort(port) {
        UrlPorts.ensureIsValid(port);

        this.port = null;

        if (this.protocol === UrlProtocols.http && port == UrlPorts.http) {
            return this;
        }

        if (this.protocol === UrlProtocols.https && port == UrlPorts.https) {
            return this;
        }

        return this.#clone(v => v.port = port);
    }

    updatePath(pathSegments) {
        pathSegments.forEach((segment, index, _) => {
            UrlStrings.ensureIsNotEmpty(segment, `pathSegments[${index}]`);
        });

        return this.#clone(v => v.pathSegments.push(...pathSegments));
    }

    updateQuery(key, value) {
        UrlStrings.ensureIsNotEmpty(key, 'key');
        UrlStrings.ensureIsNotEmpty(value, 'value');

        return this.#clone(v => v.queries[key] = value);
    }

    #clone(changes) {
        const updatedValues = new UrlValues(this.protocol, this.host);

        updatedValues.port = this.port;
        updatedValues.pathSegments = [...this.pathSegments];
        updatedValues.queries = { ...this.queries };

        changes(updatedValues);

        return updatedValues;
    }
}