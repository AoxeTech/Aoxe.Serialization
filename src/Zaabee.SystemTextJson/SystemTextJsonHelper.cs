using System;
using System.IO;
using System.Text.Json;
using Zaabee.Extensions;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonHelper
    {
        public static JsonSerializerOptions DefaultJsonSerializerOptions { get; set; }

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

        public static byte[] Serialize<T>(T o, JsonSerializerOptions options = null) =>
            SystemTextJsonSerializer.Serialize(o, options ?? DefaultJsonSerializerOptions);

        public static byte[] Serialize(Type type, object value, JsonSerializerOptions options = null) =>
            SystemTextJsonSerializer.Serialize(type, value, options ?? DefaultJsonSerializerOptions);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerOptions options = null) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : SystemTextJsonSerializer.Deserialize<T>(bytes, options ?? DefaultJsonSerializerOptions);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerOptions options = null) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : SystemTextJsonSerializer.Deserialize(type, bytes, options ?? DefaultJsonSerializerOptions);

        public static MemoryStream Pack<T>(T value, JsonSerializerOptions options = null) =>
            value is null
                ? new MemoryStream()
                : SystemTextJsonSerializer.Pack(value, options ?? DefaultJsonSerializerOptions);

        public static void Pack<T>(T value, Stream stream, JsonSerializerOptions options = null)
        {
            if (value is null || stream is null) return;
            SystemTextJsonSerializer.Pack(value, stream, options ?? DefaultJsonSerializerOptions);
        }
            

        public static MemoryStream Pack(Type type, object value, JsonSerializerOptions options = null) =>
            value is null
                ? new MemoryStream()
                : SystemTextJsonSerializer.Pack(type, value, options ?? DefaultJsonSerializerOptions);

        public static void Pack(Type type, object value, Stream stream, JsonSerializerOptions options = null)
        {
            if (value is null || stream is null) return;
            SystemTextJsonSerializer.Pack(type, value, stream, options ?? DefaultJsonSerializerOptions);
        }

        public static T Unpack<T>(Stream stream, JsonSerializerOptions options = null) =>
            stream.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : SystemTextJsonSerializer.Unpack<T>(stream, options ?? DefaultJsonSerializerOptions);

        public static object Unpack(Type type, Stream stream, JsonSerializerOptions options = null) =>
            stream.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : SystemTextJsonSerializer.Unpack(type, stream, options ?? DefaultJsonSerializerOptions);
    }
}