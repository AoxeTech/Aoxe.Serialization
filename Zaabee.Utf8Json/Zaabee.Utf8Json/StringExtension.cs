using System;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class StringExtension
    {
        public static T FromJson<T>(this string json) =>
            Utf8JsonHelper.Deserialize<T>(json);

        public static object FromJson(this string json, Type type) =>
            Utf8JsonHelper.Deserialize(type, json);

        public static object FromJson(this string json, Type type, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Deserialize(type, json, resolver);
    }
}