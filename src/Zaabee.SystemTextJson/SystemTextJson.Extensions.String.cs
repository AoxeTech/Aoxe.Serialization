using System;
using System.Text.Json;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonExtensions
    {
        public static T FromJson<T>(this string json, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Deserialize<T>(json, options);

        public static object FromJson(this string json, Type type, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Deserialize(type, json, options);
    }
}