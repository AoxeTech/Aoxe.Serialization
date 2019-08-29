using System;
using System.IO;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class Utf8JsonHelper
    {
        public static string SerializeToJson<T>(T o) =>
            JsonSerializer.ToJsonString(o);

        public static string SerializeToJson(object value) =>
            JsonSerializer.NonGeneric.ToJsonString(value);

        public static string SerializeToJson(Type type, object value) =>
            JsonSerializer.NonGeneric.ToJsonString(type, value);

        public static string SerializeToJson(object value, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.ToJsonString(value, resolver);

        public static string SerializeToJson(Type type, object value, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.ToJsonString(type, value, resolver);

        public static T Deserialize<T>(string json) =>
            string.IsNullOrWhiteSpace(json) ? default(T) : JsonSerializer.Deserialize<T>(json);

        public static object Deserialize(Type type, string json) =>
            string.IsNullOrWhiteSpace(json) ? null : JsonSerializer.NonGeneric.Deserialize(type, json);

        public static object Deserialize(Type type, string json, IJsonFormatterResolver resolver) =>
            string.IsNullOrWhiteSpace(json) ? null : JsonSerializer.NonGeneric.Deserialize(type, json, resolver);

        public static byte[] Serialize<T>(T o) =>
            JsonSerializer.Serialize(o);

        public static byte[] Serialize(object value) =>
            JsonSerializer.NonGeneric.Serialize(value);

        public static byte[] Serialize(Type type, object value) =>
            JsonSerializer.NonGeneric.Serialize(type, value);

        public static byte[] Serialize(object value, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(value, resolver);

        public static byte[] Serialize(Type type, object value, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(type, value, resolver);

        public static T Deserialize<T>(byte[] bytes) =>
            bytes == null ? default(T) : JsonSerializer.Deserialize<T>(bytes);

        public static object Deserialize(Type type, byte[] bytes) =>
            bytes == null ? null : JsonSerializer.NonGeneric.Deserialize(type, bytes);

        public static object Deserialize(Type type, byte[] bytes, IJsonFormatterResolver resolver) =>
            bytes == null ? null : JsonSerializer.NonGeneric.Deserialize(type, bytes, resolver);

        public static void Pack<T>(T value, Stream stream) =>
            JsonSerializer.Serialize(stream, value);

        public static void Pack<T>(T value, Stream stream, IJsonFormatterResolver resolver) =>
            JsonSerializer.Serialize(stream, value, resolver);

        public static void Pack(object value, Stream stream) =>
            JsonSerializer.NonGeneric.Serialize(stream, value);

        public static void Pack(Type type, object value, Stream stream) =>
            JsonSerializer.NonGeneric.Serialize(type, stream, value);

        public static void Pack(object value, Stream stream, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(stream, value, resolver);

        public static void Pack(Type type, object value, Stream stream, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(type, stream, value, resolver);

        public static T Unpack<T>(Stream stream) =>
            JsonSerializer.Deserialize<T>(stream);

        public static T Unpack<T>(Stream stream, IJsonFormatterResolver resolver) =>
            JsonSerializer.Deserialize<T>(stream, resolver);

        public static object Unpack(Type type, Stream stream) =>
            JsonSerializer.NonGeneric.Deserialize(type, stream);

        public static object Unpack(Type type, Stream stream, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Deserialize(type, stream, resolver);
    }
}