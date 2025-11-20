import UrlBuilder from '../src/url-builder.ts';

import urlBuilderInvalidTests from './url-builder-base-invalid.tests.ts';
import urlBuilderValidTests from './url-builder-base-valid.tests.ts';

urlBuilderInvalidTests(UrlBuilder.https);
urlBuilderValidTests(UrlBuilder.https, 443);