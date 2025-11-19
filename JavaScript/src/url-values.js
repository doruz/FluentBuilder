import { UrlPorts, UrlProtocols } from './url-constants.js';
import UrlStrings from './url-strings.js';

export default class UrlValues {
    protocol;
    host;
    port = null;
    pathSegments = [];
    queries = new Map();

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

        return this.#newInstance(values => values.port = port);
    }

    updatePath(pathSegments) {
        pathSegments.forEach((segment, index, _) => {
            UrlStrings.ensureIsNotEmpty(segment, `pathSegments[${index}]`);
        });

        return this.#newInstance(b => b.pathSegments = [...this.pathSegments, ...pathSegments]);
    }

    updateQuery(key, value) {
        UrlStrings.ensureIsNotEmpty(key, 'key');
        UrlStrings.ensureIsNotEmpty(value, 'value');

        return this.#newInstance(b => {
            for (const existingKey in this.queries) {
                b.queries[existingKey] = this.queries[existingKey];
            }

            b.queries[key] = value;
        });
    }

    #newInstance(changes) {
        const updatedValues = new UrlValues(this.protocol, this.host);

        changes(updatedValues);

        return updatedValues;
    }
}