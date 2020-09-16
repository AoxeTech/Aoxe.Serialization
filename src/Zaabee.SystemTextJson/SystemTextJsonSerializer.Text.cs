using System;
using System.Text.Json;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonSerializer
    {
        public static string SerializeToJson<T>(T o, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(o, options);

        public static string SerializeToJson(Type type, object value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(value, type, options);

        public static T Deserialize<T>(string json, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize<T>(json, options);

        public static object Deserialize(Type type, string json, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize(json, type, options);
    }
}