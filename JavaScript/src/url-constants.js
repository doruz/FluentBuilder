export class UrlProtocols {
    static http = 'http';
    static https = 'https';
}

export class UrlPorts {
    static #minAllowed = 1;
    static #maxAllowed = 65535;

    static http = 80;
    static https = 443;

    static ensureIsValid(port) {
        if (isNaN(port)) {
            this.#throwInvalidPortError();
        }

        if (this.#minAllowed <= port && port <= this.#maxAllowed) {
            return port;
        }

        this.#throwInvalidPortError();
    }

    static #throwInvalidPortError() {
        throw new Error(`Port should have value between ${this.#minAllowed} and ${this.#maxAllowed}.`);
    }
}