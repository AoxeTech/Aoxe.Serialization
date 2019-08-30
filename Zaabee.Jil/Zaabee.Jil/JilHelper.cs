using System;
using System.IO;
using System.Text;
using Jil;

namespace Zaabee.Jil
{
    public static class JilHelper
    {
        public static Encoding Encoding = Encoding.UTF8;

        public static byte[] Serialize<T>(T t, Options options = null)
        {
            if (t == null) return new byte[0];
            var json = JSON.Serialize(t, options);
            return Encoding.GetBytes(json);
        }

        public static Stream Pack<T>(T t, Options options = null)
        {
            if (t == null) return new MemoryStream();
            var json = JSON.Serialize(t, options);
            return new MemoryStream(Encoding.GetBytes(json));
        }

        public static void Pack<T>(T t, Stream stream, Options options = null)
        {
            if (t == null || !stream.CanWrite) return;
            var json = JSON.Serialize(t, options);
            var bytes = Encoding.GetBytes(json);
            stream.Write(bytes, 0, bytes.Length);
        }

        public static string SerializeToJson<T>(T t, Options options = null)
        {
            return t == null ? string.Empty : JSON.Serialize(t, options);
        }

        public static void Serialize<T>(T t, TextWriter output, Options options = null)
        {
            if (t != null) JSON.Serialize(t, output, options);
        }

        public static void Serialize(object obj, TextWriter textWriter, Options options = null)
        {
            if (obj != null) JSON.SerializeDynamic(obj, textWriter, options);
        }

        public static T Deserialize<T>(byte[] bytes, Options options = null)
        {
            if (bytes == null || bytes.Length == 0) return default(T);
            var json = Encoding.GetString(bytes);
            return JSON.Deserialize<T>(json, options);
        }

        public static T Unpack<T>(Stream stream, Options options = null)
        {
            if (stream == null) return default(T);
            var bytes = StreamToBytes(stream);
            var json = Encoding.GetString(bytes);
            return JSON.Deserialize<T>(json, options);
        }

        public static T Deserialize<T>(string json, Options options = null)
        {
            return string.IsNullOrWhiteSpace(json) ? default(T) : JSON.Deserialize<T>(json, options);
        }

        public static string SerializeToJson(object obj, Options options = null)
        {
            return obj is null ? string.Empty : JSON.SerializeDynamic(obj, options);
        }

        public static object Deserialize(Type type, byte[] bytes, Options options = null)
        {
            if (bytes == null || bytes.Length == 0) return default(Type);
            var json = Encoding.GetString(bytes);
            return JSON.Deserialize(json, type, options);
        }

        public static object Unpack(Type type, Stream stream, Options options = null)
        {
            if (stream == null) return default(Type);
            var bytes = StreamToBytes(stream);
            var json = Encoding.GetString(bytes);
            return JSON.Deserialize(json, type, options);
        }

        public static object Deserialize(Type type, string json, Options options = null)
        {
            return string.IsNullOrWhiteSpace(json) ? default(Type) : JSON.Deserialize(json, type, options);
        }

        public static T Deserialize<T>(TextReader reader, Options options = null) =>
            reader == null ? default(T) : JSON.Deserialize<T>(reader, options);

        public static object Deserialize(Type type, TextReader reader, Options options = null) =>
            reader == null ? default(Type) : JSON.Deserialize(reader, type, options);

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