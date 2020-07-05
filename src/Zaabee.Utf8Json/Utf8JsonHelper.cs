using System;
using System.IO;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonHelper
    {
        public static IJsonFormatterResolver DefaultJsonFormatterResolver { get; set; }

        public static string SerializeToJson<T>(T value, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.SerializeToJson(value, resolver ?? DefaultJsonFormatterResolver);

        public static string SerializeToJson(object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.SerializeToJson(obj, resolver ?? DefaultJsonFormatterResolver);

        public static string SerializeToJson(Type type, object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.SerializeToJson(type, obj, resolver ?? DefaultJsonFormatterResolver);

        public static T Deserialize<T>(string json, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Deserialize<T>(json, resolver ?? DefaultJsonFormatterResolver);

        public static object Deserialize(Type type, string json, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Deserialize(type, json, resolver ?? DefaultJsonFormatterResolver);

        public static byte[] Serialize<T>(T value, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Serialize(value, resolver ?? DefaultJsonFormatterResolver);

        public static byte[] Serialize(object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Serialize(obj, resolver ?? DefaultJsonFormatterResolver);

        public static byte[] Serialize(Type type, object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Serialize(type, obj, resolver ?? DefaultJsonFormatterResolver);

        public static T Deserialize<T>(byte[] bytes, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Deserialize<T>(bytes, resolver ?? DefaultJsonFormatterResolver);

        public static object Deserialize(Type type, byte[] bytes, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Deserialize(type, bytes, resolver ?? DefaultJsonFormatterResolver);

        public static MemoryStream Pack<T>(T value, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Pack(value, resolver ?? DefaultJsonFormatterResolver);

        public static void Pack<T>(T value, Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Pack(value, stream, resolver ?? DefaultJsonFormatterResolver);

        public static MemoryStream Pack(object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Pack(obj, resolver ?? DefaultJsonFormatterResolver);

        public static void Pack(object obj, Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Pack(obj, stream, resolver ?? DefaultJsonFormatterResolver);

        public static MemoryStream Pack(Type type, object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Pack(type, obj, resolver ?? DefaultJsonFormatterResolver);

        public static void Pack(Type type, object obj, Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Pack(type, obj, stream, resolver ?? DefaultJsonFormatterResolver);

        public static T Unpack<T>(Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Unpack<T>(stream, resolver ?? DefaultJsonFormatterResolver);

        public static object Unpack(Type type, Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Unpack(type, stream, resolver ?? DefaultJsonFormatterResolver);
    }
}