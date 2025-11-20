import { describe, it } from 'node:test';
import assert from 'node:assert';

export default function urlBuilderValidTests(host, defaultPort) {

    const protocol = host.name;

    describe(`creating valid ${protocol} urls`, () => {
        it('returns url with host', () => {
            const expected = `${protocol}://www.travel.eu`;

            const actual = host('www.travel.eu').toString();

            assert.strictEqual(actual, expected);
        });

        it('returns url with host when using default port', () => {
            const expected = `${protocol}://www.travel.eu`;

            const actual = host('www.travel.eu')
                .port(defaultPort)
                .toString();

            assert.strictEqual(actual, expected);
        });

        it('returns url with host and port when using non-default', () => {
            const expected = `${protocol}://www.travel.eu:5001`;

            const actual = host('www.travel.eu')
                .port(5001)
                .toString();

            assert.strictEqual(actual, expected);
        });

        it('returns url with host and path', () => {
            const expected = `${protocol}://www.travel.eu/countries/romania/cities/iasi`;

            const actual = host('www.travel.eu')
                .path(['countries', 'romania'])
                .path(['cities', 'iasi'])
                .toString();

            assert.strictEqual(actual, expected);
        });

        it('returns url with host, path and query', () => {
            const expected = `${protocol}://www.travel.eu/countries/romania?lang=en`;

            const actual = host('www.travel.eu')
                .path(['countries', 'romania'])
                .query('lang', 'en')
                .toString();

            assert.strictEqual(actual, expected);
        });

        it('returns url with host, path and last provided query value', () => {
            const expected = `${protocol}://www.travel.eu/countries/romania?lang=ro`;

            const actual = host('www.travel.eu')
                .path(['countries', 'romania'])
                .query('lang', 'en')
                .query('lang', 'ro')
                .toString();

            assert.strictEqual(actual, expected);
        });

        it('returns url with host, port, path and queries', () => {
            const expected = `${protocol}://www.travel.eu:5001/countries/romania?lang=en&type=nature`;

            const actual = host('www.travel.eu')
                .port(5001)
                .path(['countries', 'romania'])
                .query('lang', 'en')
                .query('type', 'nature')
                .toString();

            assert.strictEqual(actual, expected);
        });

        it('reuses details from same builder instance', () => {
            const builder = host('www.travel.eu')
                .path(['countries', 'romania']);

            // assert #1
            assert.strictEqual(
                builder.path(['cities', 'iasi']).toString(),
                `${protocol}://www.travel.eu/countries/romania/cities/iasi`
            );

            // assert #2
            assert.strictEqual(
                builder.query('lang', 'en').toString(),
                `${protocol}://www.travel.eu/countries/romania?lang=en`
            );
        })
    });
};