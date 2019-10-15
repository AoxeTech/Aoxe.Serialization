using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonHelper
    {
        public static async Task<string> SerializeToJsonAsync<T>(T o, JsonSerializerOptions options = null) =>
            await Task.Run(() => JsonSerializer.Serialize(o, options));

        public static async Task<string> SerializeToJsonAsync(Type type, object value,
            JsonSerializerOptions options = null) =>
            await Task.Run(() => JsonSerializer.Serialize(value, type, options));

        public static async Task<T> DeserializeAsync<T>(string json, JsonSerializerOptions options = null) =>
            string.IsNullOrWhiteSpace(json)
                ? default
                : await Task.Run(() => JsonSerializer.Deserialize<T>(json, options));

        public static async Task<object>
            DeserializeAsync(Type type, string json, JsonSerializerOptions options = null) =>
            string.IsNullOrWhiteSpace(json)
                ? default(Type)
                : await Task.Run(() => JsonSerializer.Deserialize(json, type, options));

        public static async Task<byte[]> SerializeAsync<T>(T o, JsonSerializerOptions options = null) =>
            await Task.Run(() => JsonSerializer.SerializeToUtf8Bytes(o, options));

        public static async Task<byte[]>
            SerializeAsync(Type type, object value, JsonSerializerOptions options = null) =>
            await Task.Run(() => JsonSerializer.SerializeToUtf8Bytes(value, type, options));

        public static async Task<T> DeserializeAsync<T>(byte[] bytes, JsonSerializerOptions options = null) =>
            bytes is null ? default : await Task.Run(() => JsonSerializer.Deserialize<T>(bytes, options));

        public static async Task<object>
            DeserializeAsync(Type type, byte[] bytes, JsonSerializerOptions options = null) =>
            bytes is null ? default(Type) : await Task.Run(() => JsonSerializer.Deserialize(bytes, type, options));

        public static async Task<Stream> PackAsync<T>(T value, JsonSerializerOptions options = null)
        {
            var ms = new MemoryStream();
            await PackAsync(value, ms, options);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static async Task PackAsync<T>(T value, Stream stream, JsonSerializerOptions options = null)
        {
            await JsonSerializer.SerializeAsync(stream, value, options);
            stream.Position = 0L;
        }

        public static async Task<Stream> PackAsync(Type type, object value, JsonSerializerOptions options = null)
        {
            var ms = new MemoryStream();
            await PackAsync(type, value, ms, options);
            return ms;
        }

        public static async Task PackAsync(Type type, object value, Stream stream,
            JsonSerializerOptions options = null)
        {
            await JsonSerializer.SerializeAsync(stream, value, type, options);
            stream.Position = 0L;
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerOptions options = null) =>
            await JsonSerializer.DeserializeAsync<T>(stream, options);

        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerOptions options = null) =>
            await JsonSerializer.DeserializeAsync(stream, type, options);
    }
}