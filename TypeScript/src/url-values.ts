import { UrlPorts, UrlProtocols } from './url-constants.ts';
import UrlStrings from './url-strings.ts';

export default class UrlValues {
    public constructor(
        public readonly protocol: string,
        public readonly host: string,
        public port: number | null = null,
        public readonly pathSegments: string[] = [],
        public readonly queries: Map<string, string> = new Map()) {

        UrlStrings.ensureIsNotEmpty(protocol, 'protocol');
        UrlStrings.ensureIsNotEmpty(host, 'host');
    }

    public updatePort(port: number): UrlValues {
        UrlPorts.ensureIsValid(port);

        if (this.protocol === UrlProtocols.http && port == UrlPorts.http) {
            return this;
        }

        if (this.protocol === UrlProtocols.https && port == UrlPorts.https) {
            return this;
        }

        return this.clone(v => v.port = port);
    }

    public updatePath(pathSegments: string[]): UrlValues {
        pathSegments.forEach((segment, index, _) => {
            UrlStrings.ensureIsNotEmpty(segment, `pathSegments[${index}]`);
        });

        return this.clone(v => v.pathSegments.push(...pathSegments));
    }

    public updateQuery(key: string, value: string): UrlValues {
        UrlStrings.ensureIsNotEmpty(key, 'key');
        UrlStrings.ensureIsNotEmpty(value, 'value');

        return this.clone(v => v.queries.set(key, value));
    }

    private clone(changes: (values: UrlValues) => void): UrlValues {
        const clonedValues = new UrlValues(
            this.protocol,
            this.host,
            this.port,
            [...this.pathSegments],
            new Map<string, string>(this.queries)
        );

        changes(clonedValues);

        return clonedValues;
    }
}