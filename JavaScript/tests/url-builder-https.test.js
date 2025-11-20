import { assert } from 'node:console';
import UrlBuilder from '../src/url-builder.js';

import urlBuilderInvalidTests from './url-builder-base-invalid.tests.js';
import urlBuilderValidTests from './url-builder-base-valid.tests.js';

urlBuilderInvalidTests(UrlBuilder.https);
urlBuilderValidTests(UrlBuilder.https, 443);