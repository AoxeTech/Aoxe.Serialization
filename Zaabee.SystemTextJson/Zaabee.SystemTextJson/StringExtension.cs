using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zaabee.SystemTextJson
{
    public static class StringExtension
    {
        public static T FromJson<T>(this string json, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Deserialize<T>(json, options);

        public static object FromJson(this string json, Type type, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Deserialize(type, json, options);

        public static async Task<T> FromJsonAsync<T>(this string json, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.DeserializeAsync<T>(json, options);

        public static async Task<object> FromJsonAsync(this string json, Type type,
            JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.DeserializeAsync(type, json, options);
    }
}