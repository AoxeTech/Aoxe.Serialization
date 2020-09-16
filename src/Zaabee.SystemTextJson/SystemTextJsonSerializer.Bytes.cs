using System;
using System.Text.Json;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonSerializer
    {
        public static byte[] Serialize<T>(T o, JsonSerializerOptions options) =>
            JsonSerializer.SerializeToUtf8Bytes(o, options);

        public static byte[] Serialize(Type type, object value, JsonSerializerOptions options) =>
            JsonSerializer.SerializeToUtf8Bytes(value, type, options);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize<T>(bytes, options);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize(bytes, type, options);
    }
}