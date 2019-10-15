using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Zaabee.Xml
{
    public static partial class XmlHelper
    {
        private static Encoding _encoding = Encoding.UTF8;

        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        public static byte[] Serialize<T>(T t) => Serialize(typeof(T), t);

        public static Stream Pack<T>(T t) => Pack(typeof(T), t);

        public static void Pack<T>(T t, Stream stream) =>
            Pack(typeof(T), t, stream);

        public static string SerializeToXml<T>(T t, Encoding encoding = null) => SerializeToXml(typeof(T), t, encoding);

        public static byte[] Serialize(Type type, object obj)
        {
            if (obj is null) return new byte[0];
            using (var stream = Pack(type, obj))
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
            var serializer = new XmlSerializer(type);
            serializer.Serialize(stream, obj);
        }

        public static string SerializeToXml(Type type, object obj, Encoding encoding = null)
        {
            if (obj is null) return string.Empty;
            encoding = encoding ?? DefaultEncoding;
            using (var stream = Pack(type, obj))
                return encoding.GetString(StreamToBytes(stream));
        }

        public static T Deserialize<T>(byte[] bytes) =>
            (T) Deserialize(typeof(T), bytes);

        public static T Unpack<T>(Stream stream) => (T) Unpack(typeof(T), stream);

        public static T Deserialize<T>(string xml, Encoding encoding = null) =>
            (T) Deserialize(typeof(T), xml, encoding);

        public static object Deserialize(Type type, byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0) return default(Type);
            var xmlSerializer = new XmlSerializer(type);
            using (var ms = new MemoryStream(bytes))
                return xmlSerializer.Deserialize(ms);
        }

        public static object Unpack(Type type, Stream stream)
        {
            if (stream is null || stream.Length == 0) return default(Type);
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            var xmlSerializer = new XmlSerializer(type);
            return xmlSerializer.Deserialize(stream);
        }

        public static object Deserialize(Type type, string xml, Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(xml)) return default(Type);
            encoding = encoding ?? DefaultEncoding;
            var xmlSerializer = new XmlSerializer(type);
            using (var ms = new MemoryStream(encoding.GetBytes(xml)))
                return xmlSerializer.Deserialize(ms);
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