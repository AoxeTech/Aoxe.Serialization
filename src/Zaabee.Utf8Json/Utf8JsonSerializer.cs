using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class Utf8JsonSerializer
    {
        #region Sync

        public static string SerializeToJson<T>(T value, IJsonFormatterResolver resolver) =>
            JsonSerializer.ToJsonString(value, resolver);

        public static string SerializeToJson(object obj, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.ToJsonString(obj, resolver);

        public static string SerializeToJson(Type type, object obj, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.ToJsonString(type, obj, resolver);

        public static T Deserialize<T>(string json, IJsonFormatterResolver resolver) =>
            string.IsNullOrWhiteSpace(json)
                ? default
                : JsonSerializer.Deserialize<T>(json, resolver);

        public static object Deserialize(Type type, string json, IJsonFormatterResolver resolver) =>
            string.IsNullOrWhiteSpace(json)
                ? default(Type)
                : JsonSerializer.NonGeneric.Deserialize(type, json, resolver);

        public static byte[] Serialize<T>(T value, IJsonFormatterResolver resolver) =>
            JsonSerializer.Serialize(value, resolver);

        public static byte[] Serialize(object obj, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(obj, resolver);

        public static byte[] Serialize(Type type, object obj, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(type, obj, resolver);

        public static T Deserialize<T>(byte[] bytes, IJsonFormatterResolver resolver) =>
            bytes is null ? default : JsonSerializer.Deserialize<T>(bytes, resolver);

        public static object Deserialize(Type type, byte[] bytes, IJsonFormatterResolver resolver) =>
            bytes is null
                ? default(Type)
                : JsonSerializer.NonGeneric.Deserialize(type, bytes, resolver);

        public static Stream Pack<T>(T value, IJsonFormatterResolver resolver)
        {
            var ms = new MemoryStream();
            Pack(value, ms, resolver);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack<T>(T value, Stream stream, IJsonFormatterResolver resolver) =>
            JsonSerializer.Serialize(stream, value, resolver);

        public static Stream Pack(object obj, IJsonFormatterResolver resolver)
        {
            var ms = new MemoryStream();
            Pack(obj, ms, resolver);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack(object obj, Stream stream, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(stream, obj, resolver);

        public static Stream Pack(Type type, object obj, IJsonFormatterResolver resolver)
        {
            var ms = new MemoryStream();
            Pack(type, obj, ms, resolver);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(type, stream, obj, resolver);

        public static T Unpack<T>(Stream stream, IJsonFormatterResolver resolver) =>
            JsonSerializer.Deserialize<T>(stream, resolver);

        public static object Unpack(Type type, Stream stream, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Deserialize(type, stream, resolver);

        #endregion

        #region Async

        public static async Task PackAsync<T>(T value, Stream stream, IJsonFormatterResolver resolver) =>
            await JsonSerializer.SerializeAsync(stream, value, resolver);

        public static async Task PackAsync(object obj, Stream stream, IJsonFormatterResolver resolver) =>
            await JsonSerializer.NonGeneric.SerializeAsync(stream, obj, resolver);

        public static async Task PackAsync(Type type, object obj, Stream stream, IJsonFormatterResolver resolver) =>
            await JsonSerializer.NonGeneric.SerializeAsync(type, stream, obj, resolver);

        public static async Task<T> UnpackAsync<T>(Stream stream, IJsonFormatterResolver resolver) =>
            await JsonSerializer.DeserializeAsync<T>(stream, resolver);

        public static async Task<object>
            UnpackAsync(Type type, Stream stream, IJsonFormatterResolver resolver) =>
            await JsonSerializer.NonGeneric.DeserializeAsync(type, stream, resolver);

        #endregion
    }
}