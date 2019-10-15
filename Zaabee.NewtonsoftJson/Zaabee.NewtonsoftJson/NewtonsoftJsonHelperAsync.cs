using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        public static async Task<byte[]> SerializeAsync(object obj, JsonSerializerSettings settings = null) =>
            obj is null
                ? new byte[0]
                : DefaultEncoding.GetBytes(await SerializeToJsonAsync(obj, settings));

        public static async Task<Stream> PackAsync(object obj, JsonSerializerSettings settings = null)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            await PackAsync(obj, ms, settings);
            return ms;
        }

        public static async Task PackAsync(object obj, Stream stream, JsonSerializerSettings settings = null)
        {
            if (obj is null) return;
            var bytes = await SerializeAsync(obj, settings);
            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        public static async Task<string> SerializeToJsonAsync(object obj, JsonSerializerSettings settings = null) =>
            obj is null
                ? string.Empty
                : await Task.Run(() => JsonConvert.SerializeObject(obj, settings ?? DefaultSettings));

        public static async Task<T> DeserializeAsync<T>(byte[] bytes, JsonSerializerSettings settings = null) =>
            (T) await DeserializeAsync(typeof(T), bytes, settings);

        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerSettings settings = null) =>
            (T) await UnpackAsync(typeof(T), stream, settings);

        public static async Task<T> DeserializeAsync<T>(string json, JsonSerializerSettings settings = null) =>
            (T) await DeserializeAsync(typeof(T), json, settings);

        public static async Task<object> DeserializeAsync(Type type, byte[] bytes,
            JsonSerializerSettings settings = null) =>
            bytes is null || bytes.Length == 0
                ? default(Type)
                : await DeserializeAsync(type, DefaultEncoding.GetString(bytes), settings);

        public static async Task<object> UnpackAsync(Type type, Stream stream,
            JsonSerializerSettings settings = null) =>
            stream is null
                ? default(Type)
                : await DeserializeAsync(type, DefaultEncoding.GetString(await StreamToBytesAsync(stream)), settings);

        public static async Task<object> DeserializeAsync(Type type, string json,
            JsonSerializerSettings settings = null) =>
            string.IsNullOrWhiteSpace(json)
                ? default(Type)
                : await Task.Run(() => JsonConvert.DeserializeObject(json, type, settings ?? DefaultSettings));

        private static async Task<byte[]> StreamToBytesAsync(Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.Position > 0 && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            await stream.ReadAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}