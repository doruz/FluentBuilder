export default class UrlStrings {
    public static ensureIsNotEmpty(value: string, parameter: string): string {
        if (value) {
            return value;
        }

        throw new Error(`Value for '${parameter}' cannot be null, undefined or empty.`);
    }
}