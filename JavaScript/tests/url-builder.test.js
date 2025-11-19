import { test } from '@jest/globals';

import UrlBuilder from '../url-builder.js';

test('when', () => {
    const url = UrlBuilder.https('www.travel.eu').toString();

    expect(url).toBe('http://wwww.travel.eu');
});