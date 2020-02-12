using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;

namespace Zaabee.Xml
{
    public static class XmlSerializer
    {
        private static readonly ConcurrentDictionary<Type, System.Xml.Serialization.XmlSerializer> SerializerCache =
            new ConcurrentDictionary<Type, System.Xml.Serialization.XmlSerializer>();

        public static byte[] Serialize<T>(T t) => Serialize(typeof(T), t);

        public static Stream Pack<T>(T t) => Pack(typeof(T), t);

        public static void Pack<T>(T t, Stream stream) => Pack(typeof(T), t, stream);

        public static string SerializeToXml<T>(T t, Encoding encoding) => SerializeToXml(typeof(T), t, encoding);

        public static byte[] Serialize(Type type, object obj)
        {
            if (obj is null) return new byte[0];
            using var stream = Pack(type, obj);
            return StreamToBytes(stream);
        }

        public static Stream Pack(Type type, object obj)
        {
            if (obj is null) return new MemoryStream();
            var ms = new MemoryStream();
            Pack(type, obj, ms);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream)
        {
            if (obj is null) return;
            var serializer = SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
            serializer.Serialize(stream, obj);
        }

        public static string SerializeToXml(Type type, object obj, Encoding encoding)
        {
            if (obj is null) return string.Empty;
            using var stream = Pack(type, obj);
            return encoding.GetString(StreamToBytes(stream));
        }

        public static T Deserialize<T>(byte[] bytes) =>
            (T) Deserialize(typeof(T), bytes);

        public static T Unpack<T>(Stream stream) => (T) Unpack(typeof(T), stream);

        public static T Deserialize<T>(string xml, Encoding encoding) =>
            (T) Deserialize(typeof(T), xml, encoding);

        public static object Deserialize(Type type, byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0) return default(Type);
            var serializer = SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
            using var ms = new MemoryStream(bytes);
            return serializer.Deserialize(ms);
        }

        public static object Unpack(Type type, Stream stream)
        {
            if (stream is null || stream.Length == 0) return default(Type);
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            var serializer = SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
            return serializer.Deserialize(stream);
        }

        public static object Deserialize(Type type, string xml, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(xml)) return default(Type);
            var serializer = SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
            using var ms = new MemoryStream(encoding.GetBytes(xml));
            return serializer.Deserialize(ms);
        }

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