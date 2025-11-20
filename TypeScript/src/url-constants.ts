export enum UrlProtocols {
    http = 'http',
    https = 'https'
}

export class UrlPorts {
    private static readonly minAllowed = 1;
    private static readonly maxAllowed = 65535;

    public static readonly http = 80;
    public static readonly https = 443;

    public static ensureIsValid(port: number): number {
        if (isNaN(port)) {
            throw this.getInvalidPortError();
        }

        if (this.minAllowed <= port && port <= this.maxAllowed) {
            return port;
        }

        throw this.getInvalidPortError();
    }

    private static getInvalidPortError(): Error {
        return Error(`Port should have value between ${this.minAllowed} and ${this.maxAllowed}.`);
    }
}