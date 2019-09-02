using System;
using System.IO;
using System.Text;
using Jil;

namespace Zaabee.Jil
{
    public static class JilHelper
    {
        private static Encoding _encoding = Encoding.UTF8;

        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        public static Options DefaultOptions;

        public static byte[] Serialize<T>(T t, Options options = null) =>
            t == null
                ? new byte[0]
                : DefaultEncoding.GetBytes(SerializeToJson(t, options));

        public static Stream Pack<T>(T t, Options options = null)
        {
            var ms = new MemoryStream();
            if (t == null) return ms;
            Pack(t, ms, options);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream, Options options = null)
        {
            if (t == null || !stream.CanWrite) return;
            var bytes = Serialize(t, options);
            stream.Write(bytes, 0, bytes.Length);
        }

        public static string SerializeToJson<T>(T t, Options options = null) =>
            t == null ? string.Empty : JSON.Serialize(t, options ?? DefaultOptions);

        public static void Serialize<T>(T t, TextWriter output, Options options = null)
        {
            if (t != null) JSON.Serialize(t, output, options ?? DefaultOptions);
        }

        public static void Serialize(object obj, TextWriter output, Options options = null)
        {
            if (obj != null) JSON.SerializeDynamic(obj, output, options ?? DefaultOptions);
        }

        public static T Deserialize<T>(byte[] bytes, Options options = null) =>
            bytes == null || bytes.Length == 0
                ? default(T)
                : JSON.Deserialize<T>(DefaultEncoding.GetString(bytes), options ?? DefaultOptions);

        public static T Unpack<T>(Stream stream, Options options = null) =>
            stream == null
                ? default(T)
                : JSON.Deserialize<T>(DefaultEncoding.GetString(StreamToBytes(stream)), options ?? DefaultOptions);

        public static T Deserialize<T>(string json, Options options = null) =>
            string.IsNullOrWhiteSpace(json) ? default(T) : JSON.Deserialize<T>(json, options ?? DefaultOptions);

        public static string SerializeToJson(object obj, Options options = null) =>
            obj is null ? string.Empty : JSON.SerializeDynamic(obj, options ?? DefaultOptions);

        public static object Deserialize(Type type, byte[] bytes, Options options = null) =>
            bytes == null || bytes.Length == 0
                ? default(Type)
                : JSON.Deserialize(DefaultEncoding.GetString(bytes), type, options ?? DefaultOptions);

        public static object Unpack(Type type, Stream stream, Options options = null) =>
            stream == null
                ? default(Type)
                : JSON.Deserialize(DefaultEncoding.GetString(StreamToBytes(stream)), type, options ?? DefaultOptions);

        public static object Deserialize(Type type, string json, Options options = null) =>
            string.IsNullOrWhiteSpace(json)
                ? default(Type)
                : JSON.Deserialize(json, type, options ?? DefaultOptions);

        public static T Deserialize<T>(TextReader reader, Options options = null) =>
            reader == null ? default(T) : JSON.Deserialize<T>(reader, options ?? DefaultOptions);

        public static object Deserialize(Type type, TextReader reader, Options options = null) =>
            reader == null ? default(Type) : JSON.Deserialize(reader, type, options ?? DefaultOptions);

        private static byte[] StreamToBytes(Stream ms)
        {
            if (ms.CanSeek && ms.Position > 0)
                ms.Position = 0;
            var bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            return bytes;
        }
    }
}