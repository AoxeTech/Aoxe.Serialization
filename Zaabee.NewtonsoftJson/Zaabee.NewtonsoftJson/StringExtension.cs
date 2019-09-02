using System;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class StringExtension
    {
        public static T FromJson<T>(this string json, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Deserialize<T>(json, settings);

        public static object FromJson(this string json, Type type, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Deserialize(type, json, settings);
    }
}