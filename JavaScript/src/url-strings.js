export default class UrlStrings {
    static ensureIsNotEmpty(value, parameter) {
        if (value) {
            return value;
        }

        throw new Error(`Value for '${parameter}' cannot be null, undefined or empty.`);
    }
}