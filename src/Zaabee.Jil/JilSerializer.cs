using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static class JilSerializer
    {
        #region Sync

        public static byte[] Serialize<T>(T t, Options options, Encoding encoding) =>
            t is null
                ? new byte[0]
                : encoding.GetBytes(SerializeToJson(t, options));

        public static Stream Pack<T>(T t, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            if (t is null) return ms;
            Pack(t, ms, options, encoding);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream, Options options, Encoding encoding)
        {
            if (t is null || !stream.CanWrite) return;
            var bytes = Serialize(t, options, encoding);
            stream.Write(bytes, 0, bytes.Length);
        }

        public static string SerializeToJson<T>(T t, Options options) =>
            t is null ? string.Empty : JSON.Serialize(t, options);

        public static void Serialize<T>(T t, TextWriter output, Options options)
        {
            if (t != null) JSON.Serialize(t, output, options);
        }

        public static void Serialize(object obj, TextWriter output, Options options)
        {
            if (obj != null) JSON.SerializeDynamic(obj, output, options);
        }

        public static T Deserialize<T>(byte[] bytes, Options options, Encoding encoding) =>
            bytes is null || bytes.Length is 0
                ? default
                : JSON.Deserialize<T>(encoding.GetString(bytes), options);

        public static T Unpack<T>(Stream stream, Options options, Encoding encoding) =>
            stream is null
                ? default
                : JSON.Deserialize<T>(encoding.GetString(StreamToBytes(stream)), options);

        public static T Deserialize<T>(string json, Options options) =>
            string.IsNullOrWhiteSpace(json) ? default : JSON.Deserialize<T>(json, options);

        public static string SerializeToJson(object obj, Options options) =>
            obj is null ? string.Empty : JSON.SerializeDynamic(obj, options);

        public static object Deserialize(Type type, byte[] bytes, Options options, Encoding encoding) =>
            bytes is null || bytes.Length is 0
                ? default(Type)
                : JSON.Deserialize(encoding.GetString(bytes), type, options);

        public static object Unpack(Type type, Stream stream, Options options, Encoding encoding) =>
            stream is null
                ? default(Type)
                : JSON.Deserialize(encoding.GetString(StreamToBytes(stream)), type, options);

        public static object Deserialize(Type type, string json, Options options) =>
            string.IsNullOrWhiteSpace(json)
                ? default(Type)
                : JSON.Deserialize(json, type, options);

        public static T Deserialize<T>(TextReader reader, Options options) =>
            reader is null ? default : JSON.Deserialize<T>(reader, options);

        public static object Deserialize(Type type, TextReader reader, Options options) =>
            reader is null ? default(Type) : JSON.Deserialize(reader, type, options);

        #endregion

        #region Async

        public static async Task PackAsync<T>(T t, Stream stream, Options options, Encoding encoding)
        {
            if (t is null || !stream.CanWrite) await Task.CompletedTask;
            var bytes = Serialize(t, options, encoding);
            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, Options options, Encoding encoding)
        {
            if (stream is null) return default;
            var bytes = await StreamToBytesAsync(stream);
            return JSON.Deserialize<T>(encoding.GetString(bytes), options);
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream, Options options, Encoding encoding)
        {
            if (stream is null) return default;
            var bytes = await StreamToBytesAsync(stream);
            return JSON.Deserialize(encoding.GetString(bytes), type, options);
        }

        #endregion

        private static byte[] StreamToBytes(Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

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