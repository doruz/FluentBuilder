import UrlStrings from './url-strings';

export default class UrlValues {

    public readonly protocol: string;
    public readonly host: string;

    constructor(protocol: string, host: string) {
        this.protocol = UrlStrings.ensureIsNotEmpty(protocol, 'protocol');
        this.host = UrlStrings.ensureIsNotEmpty(host, 'host');
    }
}