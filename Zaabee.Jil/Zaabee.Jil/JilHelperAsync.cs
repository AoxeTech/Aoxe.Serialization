using System;
using System.IO;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        public static async Task<byte[]> SerializeAsync<T>(T t, Options options = null) =>
            t == null
                ? new byte[0]
                : DefaultEncoding.GetBytes(await SerializeToJsonAsync(t, options));

        public static async Task<Stream> PackAsync<T>(T t, Options options = null)
        {
            var ms = new MemoryStream();
            if (t == null) return ms;
            await PackAsync(t, ms, options);
            return ms;
        }

        public static async Task PackAsync<T>(T t, Stream stream, Options options = null)
        {
            if (t == null || !stream.CanWrite) return;
            var bytes = await SerializeAsync(t, options);
            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        public static async Task<string> SerializeToJsonAsync<T>(T t, Options options = null) =>
            t == null ? string.Empty : await Task.Run(() => JSON.Serialize(t, options ?? DefaultOptions));

        public static async Task SerializeAsync<T>(T t, TextWriter output, Options options = null)
        {
            if (t != null) await Task.Run(() => JSON.Serialize(t, output, options ?? DefaultOptions));
        }

        public static async Task SerializeAsync(object obj, TextWriter output, Options options = null)
        {
            if (obj != null) await Task.Run(() => JSON.SerializeDynamic(obj, output, options ?? DefaultOptions));
        }

        public static async Task<T> DeserializeAsync<T>(byte[] bytes, Options options = null) =>
            bytes == null || bytes.Length == 0
                ? default(T)
                : await Task.Run(() =>
                    JSON.Deserialize<T>(DefaultEncoding.GetString(bytes), options ?? DefaultOptions));

        public static async Task<T> UnpackAsync<T>(Stream stream, Options options = null) =>
            stream == null
                ? default(T)
                : await Task.Run(() =>
                    JSON.Deserialize<T>(DefaultEncoding.GetString(StreamToBytes(stream)), options ?? DefaultOptions));

        public static async Task<T> DeserializeAsync<T>(string json, Options options = null) =>
            string.IsNullOrWhiteSpace(json)
                ? default(T)
                : await Task.Run(() => JSON.Deserialize<T>(json, options ?? DefaultOptions));

        public static async Task<string> SerializeToJsonAsync(object obj, Options options = null) =>
            obj is null ? string.Empty : await Task.Run(() => JSON.SerializeDynamic(obj, options ?? DefaultOptions));

        public static async Task<object> DeserializeAsync(Type type, byte[] bytes, Options options = null) =>
            bytes == null || bytes.Length == 0
                ? default(Type)
                : await Task.Run(() =>
                    JSON.Deserialize(DefaultEncoding.GetString(bytes), type, options ?? DefaultOptions));

        public static async Task<object> UnpackAsync(Type type, Stream stream, Options options = null) =>
            stream == null
                ? default(Type)
                : await Task.Run(() => JSON.Deserialize(DefaultEncoding.GetString(StreamToBytes(stream)), type,
                    options ?? DefaultOptions));

        public static async Task<object> DeserializeAsync(Type type, string json, Options options = null) =>
            string.IsNullOrWhiteSpace(json)
                ? default(Type)
                : await Task.Run(() => JSON.Deserialize(json, type, options ?? DefaultOptions));

        public static async Task<T> DeserializeAsync<T>(TextReader reader, Options options = null) =>
            reader == null ? default(T) : await Task.Run(() => JSON.Deserialize<T>(reader, options ?? DefaultOptions));

        public static async Task<object> DeserializeAsync(Type type, TextReader reader, Options options = null) =>
            reader == null
                ? default(Type)
                : await Task.Run(() => JSON.Deserialize(reader, type, options ?? DefaultOptions));

        private static async Task<byte[]> StreamToBytesAsync(Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
            await stream.ReadAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}