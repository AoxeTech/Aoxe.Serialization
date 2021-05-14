using System;
using System.Text.Json;
using Zaabee.Extensions;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonHelper
    {
        public static string SerializeToJson<T>(T o, JsonSerializerOptions options = null) =>
            SystemTextJsonSerializer.SerializeToJson(o, options ?? DefaultJsonSerializerOptions);

        public static string SerializeToJson(Type type, object value, JsonSerializerOptions options = null) =>
            SystemTextJsonSerializer.SerializeToJson(type, value, options ?? DefaultJsonSerializerOptions);

        public static T Deserialize<T>(string json, JsonSerializerOptions options = null) =>
            json.IsNullOrWhiteSpace()
                ? (T) typeof(T).GetDefaultValue()
                : SystemTextJsonSerializer.Deserialize<T>(json, options ?? DefaultJsonSerializerOptions);

        public static object Deserialize(Type type, string json, JsonSerializerOptions options = null) =>
            json.IsNullOrWhiteSpace()
                ? type.GetDefaultValue()
                : SystemTextJsonSerializer.Deserialize(type, json, options ?? DefaultJsonSerializerOptions);
    }
}