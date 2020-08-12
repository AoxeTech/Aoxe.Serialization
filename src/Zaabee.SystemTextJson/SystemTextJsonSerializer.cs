using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Zaabee.Extensions;

namespace Zaabee.SystemTextJson
{
    public static class SystemTextJsonSerializer
    {
        #region Bytes

        public static byte[] Serialize<T>(T o, JsonSerializerOptions options) =>
            JsonSerializer.SerializeToUtf8Bytes(o, options);

        public static byte[] Serialize(Type type, object value, JsonSerializerOptions options) =>
            JsonSerializer.SerializeToUtf8Bytes(value, type, options);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerOptions options) =>
            bytes.IsNullOrEmpty() ? default : JsonSerializer.Deserialize<T>(bytes, options);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerOptions options) =>
            bytes.IsNullOrEmpty() ? type.GetDefaultValue() : JsonSerializer.Deserialize(bytes, type, options);

        #endregion

        #region Stream

        public static MemoryStream Pack<T>(T value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            Pack(value, ms, options);
            return ms;
        }

        public static void Pack<T>(T value, Stream stream, JsonSerializerOptions options)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(value, options);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            stream.Write(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
        }

        public static MemoryStream Pack(Type type, object value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            Pack(type, value, ms, options);
            return ms;
        }

        public static void Pack(Type type, object value, Stream stream, JsonSerializerOptions options)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(value, type, options);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            stream.Write(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream, JsonSerializerOptions options) =>
            Unpack<T>(stream.ReadToEnd(), options);

        public static object Unpack(Type type, Stream stream, JsonSerializerOptions options) =>
            Unpack(type, stream.ReadToEnd(), options);

        public static async Task PackAsync<T>(T value, Stream stream, JsonSerializerOptions options)
        {
            await JsonSerializer.SerializeAsync(stream, value, options);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
        }

        public static async Task PackAsync(Type type, object value, Stream stream,
            JsonSerializerOptions options)
        {
            await JsonSerializer.SerializeAsync(stream, value, type, options);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerOptions options)
        {
            var result = await JsonSerializer.DeserializeAsync<T>(stream, options);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return result;
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerOptions options)
        {
            var result = await JsonSerializer.DeserializeAsync(stream, type, options);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return result;
        }

        #endregion

        #region Text

        public static string SerializeToJson<T>(T o, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(o, options);

        public static string SerializeToJson(Type type, object value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(value, type, options);

        public static T Deserialize<T>(string json, JsonSerializerOptions options) =>
            string.IsNullOrWhiteSpace(json)
                ? default
                : JsonSerializer.Deserialize<T>(json, options);

        public static object Deserialize(Type type, string json, JsonSerializerOptions options) =>
            string.IsNullOrWhiteSpace(json)
                ? type.GetDefaultValue()
                : JsonSerializer.Deserialize(json, type, options);

        #endregion

        #region ReadOnlySpan<byte>

        public static T Unpack<T>(ReadOnlySpan<byte> spanBytes, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize<T>(spanBytes, options);

        public static object Unpack(Type type, ReadOnlySpan<byte> spanBytes, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize(spanBytes, type, options);

        #endregion
    }
}