using System;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class StringExtension
    {
        /// <summary>
        /// Deserialize the json to the generic object(if the string is null or white space then return default(T))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromUtf8Json<T>(this string json) =>
            Utf8JsonHelper.Deserialize<T>(json);

        public static object FromUtf8Json(this string json, Type type) =>
            Utf8JsonHelper.Deserialize(type, json);

        public static object FromUtf8Json(this string json, Type type, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Deserialize(type, json, resolver);
    }
}