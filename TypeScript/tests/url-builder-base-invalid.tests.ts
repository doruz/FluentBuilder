import { describe, it } from 'node:test';
import assert from 'node:assert';

import type UrlBuilder from '../src/url-builder.ts';

export default function urlBuilderInvalidTests(host: (address: string) => UrlBuilder) {

    const protocol = host.name;

    describe(`creating invalid ${protocol} urls`, () => {
        it('throws exception for empty host', () => {
            assert.throws(() => host('').toString());
        });

        it('throws exception for null host', () => {
            assert.throws(() => host(null!).toString());
        });

        it('throws exception for undefined host', () => {
            assert.throws(() => host(undefined!).toString());
        });


        it('throws exception for empty path', () => {
            assert.throws(() => host('www.travel.eu')
                .path([''])
                .toString()
            );
        });

        it('throws exception for null path', () => {
            assert.throws(() => host('www.travel.eu')
                .path([null!])
                .toString()
            );
        });

        it('throws exception for undefined path', () => {
            assert.throws(() => host('www.travel.eu')
                .path([undefined!])
                .toString()
            );
        });


        it('throws exception for empty query key', () => {
            assert.throws(() => host('www.travel.eu')
                .query('', 'en')
                .toString()
            );
        });

        it('throws exception for empty query value', () => {
            assert.throws(() => host('www.travel.eu')
                .query('lang', '')
                .toString()
            );
        });

        it('throws exception for null query key', () => {
            assert.throws(() => host('www.travel.eu')
                .query(null!, 'en')
                .toString()
            );
        });

        it('throws exception for null query value', () => {
            assert.throws(() => host('www.travel.eu')
                .query('lang', null!)
                .toString()
            );
        });

        it('throws exception for undefined query key', () => {
            assert.throws(() => host('www.travel.eu')
                .query(undefined!, 'en')
                .toString()
            );
        });

        it('throws exception for undefined query value', () => {
            assert.throws(() => host('www.travel.eu')
                .query('lang', undefined!)
                .toString()
            );
        });
    });
};

// TODO: testing githug workflow
describe(`testing gated`, () => {
    it('should fails', () => {
        assert.strictEqual(1, 2);
    });
});