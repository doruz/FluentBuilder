namespace FluentBuilder.Url
{
    public sealed class QueryString
    {
        internal string Key { get; private set; }

        internal string Value { get; private set; }

        internal bool IsInitialized => !string.IsNullOrEmpty(Key);

        internal QueryString()
        {
        }

        public QueryString HavingKey(string key)
        {
            Key = key;
            return this;
        }

        public QueryString WithValue(string value)
        {
            Value = value;
            return this;
        }

        public override string ToString()
        {
            return $"{Key}={Value}";
        }
    }
}