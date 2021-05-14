using System;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonExtensions
    {
        public static T FromJson<T>(this string json, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Deserialize<T>(json, resolver);

        public static object FromJson(this string json, Type type, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Deserialize(type, json, resolver);
    }
}