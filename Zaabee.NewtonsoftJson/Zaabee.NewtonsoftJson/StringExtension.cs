using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class StringExtension
    {
        public static T FromJson<T>(this string json, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Deserialize<T>(json, settings);

        public static object FromJson(this string json, Type type, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Deserialize(type, json, settings);

        public static async Task<T> FromJsonAsync<T>(this string json, JsonSerializerSettings settings = null) =>
            await NewtonsoftJsonHelper.DeserializeAsync<T>(json, settings);

        public static async Task<object> FromJsonAsync(this string json, Type type,
            JsonSerializerSettings settings = null) =>
            await NewtonsoftJsonHelper.DeserializeAsync(type, json, settings);
    }
}