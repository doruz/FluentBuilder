using System;
using System.Collections.Generic;

namespace FluentBuilder.Url
{
    public class UrlBuilder : ISegmentBuilder, IQueryStringBuilder, IBaseUrlBuilder
    {
        private readonly string baseAddress;
        private readonly List<string> segments;
        private readonly SortedDictionary<string, string> queryStrings;

        private UrlBuilder(string protocol, string address)
        {
            baseAddress = $"{protocol}://{address}";
            segments = new List<string>();
            queryStrings = new SortedDictionary<string, string>();
        }

        public static UrlBuilder Http(string address)
        {
            return new UrlBuilder("http", address);
        }

        public static UrlBuilder Https(string address)
        {
            return new UrlBuilder("https", address);
        }

        public ISegmentBuilder WithSegment(string segment)
        {
            if (!string.IsNullOrEmpty(segment))
            {
                segments.Add(segment);
            }

            return this;
        }

        public IQueryStringBuilder WithQueryString(Action<QueryString> initializer)
        {
            var query = new QueryString();
            initializer(query);

            if (query.IsInitialized)
            {
                queryStrings[query.Key.ToLower()] = query.ToString();
            }

            return this;
        }

        public string ToUrl()
        {
            var segmentsString = string.Join("/", segments);
            var queries = string.Join("&", queryStrings.Values);

            return $"{baseAddress}/{segmentsString}?{queries}";
        }
    }
}
