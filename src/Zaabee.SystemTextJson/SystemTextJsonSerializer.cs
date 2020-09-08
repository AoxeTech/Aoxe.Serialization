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
            JsonSerializer.Deserialize<T>(bytes, options);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize(bytes, type, options);

        #endregion

        #region Stream

        public static MemoryStream Pack<T>(T value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            Pack(value, ms, options);
            return ms;
        }

        public static MemoryStream Pack(Type type, object value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            Pack(type, value, ms, options);
            return ms;
        }

        public static void Pack<T>(T value, Stream stream, JsonSerializerOptions options)
        {
            JsonSerializer.SerializeToUtf8Bytes(value, options).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static void Pack(Type type, object value, Stream stream, JsonSerializerOptions options)
        {
            JsonSerializer.SerializeToUtf8Bytes(value, type, options).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream, JsonSerializerOptions options)
        {
            var result = Deserialize<T>(stream.ReadToEnd(), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static object Unpack(Type type, Stream stream, JsonSerializerOptions options)
        {
            var result = Deserialize(type, stream.ReadToEnd(), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static async Task<MemoryStream> PackAsync<T>(T value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            await PackAsync(value, ms, options);
            return ms;
        }

        public static async Task<MemoryStream> PackAsync(Type type, object value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            await PackAsync(type, value, ms, options);
            return ms;
        }

        public static async Task PackAsync<T>(T value, Stream stream, JsonSerializerOptions options)
        {
            await JsonSerializer.SerializeAsync(stream, value, options);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task PackAsync(Type type, object value, Stream stream, JsonSerializerOptions options)
        {
            await JsonSerializer.SerializeAsync(stream, value, type, options);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerOptions options)
        {
            var result = await JsonSerializer.DeserializeAsync<T>(stream, options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerOptions options)
        {
            var result = await JsonSerializer.DeserializeAsync(stream, type, options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        #endregion

        #region Text

        public static string SerializeToJson<T>(T o, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(o, options);

        public static string SerializeToJson(Type type, object value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(value, type, options);

        public static T Deserialize<T>(string json, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize<T>(json, options);

        public static object Deserialize(Type type, string json, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize(json, type, options);

        #endregion
    }
}