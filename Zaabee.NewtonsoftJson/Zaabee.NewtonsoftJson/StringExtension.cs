using System;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class StringExtension
    {
        public static T FromJson<T>(this string json, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            NewtonsoftJsonHelper.Deserialize<T>(json, settings, formatting);

        public static object FromJson(this string json, Type type, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            NewtonsoftJsonHelper.Deserialize(type, json);
    }
}