using System;
using System.IO;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonHelper
    {
        public static string SerializeToJson<T>(T o, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.ToJsonString(o, resolver);

        public static string SerializeToJson(object value, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.NonGeneric.ToJsonString(value, resolver);

        public static string SerializeToJson(Type type, object value, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.NonGeneric.ToJsonString(type, value, resolver);

        public static T Deserialize<T>(string json, IJsonFormatterResolver resolver = null) =>
            string.IsNullOrWhiteSpace(json) ? default(T) : JsonSerializer.Deserialize<T>(json, resolver);

        public static object Deserialize(Type type, string json, IJsonFormatterResolver resolver = null) =>
            string.IsNullOrWhiteSpace(json) ? default(Type) : JsonSerializer.NonGeneric.Deserialize(type, json, resolver);

        public static byte[] Serialize<T>(T o, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.Serialize(o, resolver);

        public static byte[] Serialize(object value, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.NonGeneric.Serialize(value, resolver);

        public static byte[] Serialize(Type type, object value, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.NonGeneric.Serialize(type, value, resolver);

        public static T Deserialize<T>(byte[] bytes, IJsonFormatterResolver resolver = null) =>
            bytes == null ? default(T) : JsonSerializer.Deserialize<T>(bytes, resolver);

        public static object Deserialize(Type type, byte[] bytes, IJsonFormatterResolver resolver = null) =>
            bytes == null ? default(Type) : JsonSerializer.NonGeneric.Deserialize(type, bytes, resolver);

        public static Stream Pack<T>(T value, IJsonFormatterResolver resolver = null)
        {
            var ms = new MemoryStream();
            Pack(value, ms, resolver);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack<T>(T value, Stream stream, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.Serialize(stream, value, resolver);

        public static Stream Pack(object value, IJsonFormatterResolver resolver = null)
        {
            var ms = new MemoryStream();
            Pack(value, ms, resolver);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack(object value, Stream stream, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.NonGeneric.Serialize(stream, value, resolver);

        public static Stream Pack(Type type, object value, IJsonFormatterResolver resolver = null)
        {
            var ms = new MemoryStream();
            JsonSerializer.NonGeneric.Serialize(type, ms, value, resolver);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack(Type type, object value, Stream stream, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.NonGeneric.Serialize(type, stream, value, resolver);

        public static T Unpack<T>(Stream stream, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.Deserialize<T>(stream, resolver);

        public static object Unpack(Type type, Stream stream, IJsonFormatterResolver resolver = null) =>
            JsonSerializer.NonGeneric.Deserialize(type, stream, resolver);
    }
}