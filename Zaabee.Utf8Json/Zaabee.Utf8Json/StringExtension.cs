using System;
using System.Threading.Tasks;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class StringExtension
    {
        public static T FromJson<T>(this string json, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Deserialize<T>(json, resolver);

        public static object FromJson(this string json, Type type, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Deserialize(type, json, resolver);

        public static async Task<T> FromJsonAsync<T>(this string json, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.DeserializeAsync<T>(json, resolver);

        public static async Task<object> FromJsonAsync(this string json, Type type,
            IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.DeserializeAsync(type, json, resolver);
    }
}