﻿namespace MyWebServer.Server.HTTP
{
    using Utils;

    public class HttpHeader
    {
        public HttpHeader(string key, string value)
        {
            Validator.CheckIfNullOrEmpty(key);
            Validator.CheckIfNullOrEmpty(value);

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
