using System;
using System.IO;
using System.Text.Json;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonHelper
    {
        public static string SerializeToJson<T>(T o, JsonSerializerOptions options = null) =>
            JsonSerializer.Serialize(o, options);

        public static string SerializeToJson(Type type, object value, JsonSerializerOptions options = null) =>
            JsonSerializer.Serialize(value, type, options);

        public static T Deserialize<T>(string json, JsonSerializerOptions options = null) =>
            string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.Deserialize<T>(json, options);

        public static object Deserialize(Type type, string json, JsonSerializerOptions options = null) =>
            string.IsNullOrWhiteSpace(json) ? default(Type) : JsonSerializer.Deserialize(json, type, options);

        public static byte[] Serialize<T>(T o, JsonSerializerOptions options = null) =>
            JsonSerializer.SerializeToUtf8Bytes(o, options);

        public static byte[] Serialize(Type type, object value, JsonSerializerOptions options = null) =>
            JsonSerializer.SerializeToUtf8Bytes(value, type, options);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerOptions options = null) =>
            bytes is null ? default : JsonSerializer.Deserialize<T>(bytes, options);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerOptions options = null) =>
            bytes is null ? default(Type) : JsonSerializer.Deserialize(bytes, type, options);

        public static Stream Pack<T>(T value, JsonSerializerOptions options = null)
        {
            var ms = new MemoryStream();
            Pack(value, ms, options);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack<T>(T value, Stream stream, JsonSerializerOptions options = null)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(value, options);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            stream.Write(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
        }

        public static Stream Pack(Type type, object value, JsonSerializerOptions options = null)
        {
            var ms = new MemoryStream();
            Pack(type, value, ms, options);
            return ms;
        }

        public static void Pack(Type type, object value, Stream stream, JsonSerializerOptions options = null)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(value, type, options);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            stream.Write(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream, JsonSerializerOptions options = null) =>
            JsonSerializer.Deserialize<T>(StreamToBytes(stream), options);

        public static object Unpack(Type type, Stream stream, JsonSerializerOptions options = null) =>
            JsonSerializer.Deserialize(StreamToBytes(stream), type, options);

        private static byte[] StreamToBytes(Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.Position > 0 && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}