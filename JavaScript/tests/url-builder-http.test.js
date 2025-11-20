import UrlBuilder from '../src/url-builder.js';

import urlBuilderInvalidTests from './url-builder-base-invalid.tests.js';
import urlBuilderValidTests from './url-builder-base-valid.tests.js';

urlBuilderInvalidTests(UrlBuilder.http);
urlBuilderValidTests(UrlBuilder.http, 80);