using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonHelper
    {
        public static async Task<string> SerializeToJsonAsync<T>(T o, IJsonFormatterResolver resolver = null) =>
            await Task.Run(() => JsonSerializer.ToJsonString(o, resolver));

        public static async Task<string> SerializeToJsonAsync(object value, IJsonFormatterResolver resolver = null) =>
            await Task.Run(() => JsonSerializer.NonGeneric.ToJsonString(value, resolver));

        public static async Task<string> SerializeToJsonAsync(Type type, object value,
            IJsonFormatterResolver resolver = null) =>
            await Task.Run(() => JsonSerializer.NonGeneric.ToJsonString(type, value, resolver));

        public static async Task<T> DeserializeAsync<T>(string json, IJsonFormatterResolver resolver = null) =>
            await Task.Run(() =>
                string.IsNullOrWhiteSpace(json) ? default(T) : JsonSerializer.Deserialize<T>(json, resolver));

        public static async Task<object> DeserializeAsync(Type type, string json,
            IJsonFormatterResolver resolver = null) =>
            string.IsNullOrWhiteSpace(json)
                ? default(Type)
                : await Task.Run(() => JsonSerializer.NonGeneric.Deserialize(type, json, resolver));

        public static async Task<byte[]> SerializeAsync<T>(T o, IJsonFormatterResolver resolver = null) =>
            await Task.Run(() => JsonSerializer.Serialize(o, resolver));

        public static async Task<byte[]> SerializeAsync(object value, IJsonFormatterResolver resolver = null) =>
            await Task.Run(() => JsonSerializer.NonGeneric.Serialize(value, resolver));

        public static async Task<byte[]>
            SerializeAsync(Type type, object value, IJsonFormatterResolver resolver = null) =>
            await Task.Run(() => JsonSerializer.NonGeneric.Serialize(type, value, resolver));

        public static async Task<T> DeserializeAsync<T>(byte[] bytes, IJsonFormatterResolver resolver = null) =>
            bytes == null ? default(T) : await Task.Run(() => JsonSerializer.Deserialize<T>(bytes, resolver));

        public static async Task<object> DeserializeAsync(Type type, byte[] bytes,
            IJsonFormatterResolver resolver = null) =>
            bytes == null
                ? default(Type)
                : await Task.Run(() => JsonSerializer.NonGeneric.Deserialize(type, bytes, resolver));

        public static async Task<Stream> PackAsync<T>(T value, IJsonFormatterResolver resolver = null)
        {
            var ms = new MemoryStream();
            await PackAsync(value, ms, resolver);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static async Task PackAsync<T>(T value, Stream stream, IJsonFormatterResolver resolver = null) =>
            await JsonSerializer.SerializeAsync(stream, value, resolver);

        public static async Task<Stream> PackAsync(object value, IJsonFormatterResolver resolver = null)
        {
            var ms = new MemoryStream();
            await PackAsync(value, ms, resolver);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static async Task PackAsync(object value, Stream stream, IJsonFormatterResolver resolver = null) =>
            await JsonSerializer.NonGeneric.SerializeAsync(stream, value, resolver);

        public static async Task<Stream> PackAsync(Type type, object value, IJsonFormatterResolver resolver = null)
        {
            var ms = new MemoryStream();
            await JsonSerializer.NonGeneric.SerializeAsync(type, ms, value, resolver);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static async Task PackAsync(Type type, object value, Stream stream,
            IJsonFormatterResolver resolver = null) =>
            await JsonSerializer.NonGeneric.SerializeAsync(type, stream, value, resolver);

        public static async Task<T> UnpackAsync<T>(Stream stream, IJsonFormatterResolver resolver = null) =>
            await JsonSerializer.DeserializeAsync<T>(stream, resolver);

        public static async Task<object>
            UnpackAsync(Type type, Stream stream, IJsonFormatterResolver resolver = null) =>
            await JsonSerializer.NonGeneric.DeserializeAsync(type, stream, resolver);
    }
}