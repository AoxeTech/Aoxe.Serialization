using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Xml;
using Zaabee.Extensions;

namespace Zaabee.Xml
{
    public static class XmlSerializer
    {
        private static readonly ConcurrentDictionary<Type, System.Xml.Serialization.XmlSerializer> SerializerCache =
            new ConcurrentDictionary<Type, System.Xml.Serialization.XmlSerializer>();

        #region Bytes

        public static byte[] Serialize<T>(T t) => Serialize(typeof(T), t);

        public static byte[] Serialize(Type type, object obj)
        {
            if (obj is null) return new byte[0];
            using var ms = Pack(type, obj);
            return ms.ToArray();
        }

        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty() ? default : (T) Deserialize(typeof(T), bytes);

        public static object Deserialize(Type type, byte[] bytes)
        {
            if (bytes.IsNullOrEmpty()) return default(Type);
            using var ms = new MemoryStream(bytes);
            return Unpack(type, ms);
        }

        #endregion

        #region Stream

        public static MemoryStream Pack<T>(T t) => Pack(typeof(T), t);

        public static void Pack<T>(T t, Stream stream) => Pack(typeof(T), t, stream);

        public static MemoryStream Pack(Type type, object obj)
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

        public static T Unpack<T>(Stream stream) => (T) Unpack(typeof(T), stream);

        public static object Unpack(Type type, Stream stream)
        {
            if (stream is null || stream.Length == 0) return default(Type);
            if (stream.CanSeek && stream.Position > 0) stream.Position = 0;
            var serializer = SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
            return serializer.Deserialize(stream);
        }

        #endregion

        #region Text

        public static string SerializeToXml<T>(T t, Encoding encoding) => SerializeToXml(typeof(T), t, encoding);

        public static string SerializeToXml(Type type, object obj, Encoding encoding)
        {
            if (obj is null) return string.Empty;
            using var ms = Pack(type, obj);
            return encoding.GetString(ms.ToArray());
        }

        public static T Deserialize<T>(string xml, Encoding encoding) =>
            (T) Deserialize(typeof(T), xml, encoding);

        public static object Deserialize(Type type, string xml, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(xml)) return default(Type);
            using var ms = new MemoryStream(encoding.GetBytes(xml));
            return Unpack(type, ms);
        }

        #endregion

        #region TextWriter/TextReader

        public static void Serialize<T>(TextWriter textWriter, object obj) => Serialize(typeof(T), textWriter, obj);

        public static void Serialize(Type type, TextWriter textWriter, object obj)
        {
            var serializer = SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
            serializer.Serialize(textWriter, obj);
        }

        public static T Deserialize<T>(TextReader textReader) => (T) Deserialize(typeof(T), textReader);

        public static object Deserialize(Type type, TextReader textReader)
        {
            if (textReader is null) return default(Type);
            var serializer = SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
            return serializer.Deserialize(textReader);
        }

        #endregion

        #region XmlWriter/XmlReader

        public static void Serialize<T>(XmlWriter xmlWriter, object obj) => Serialize(typeof(T), xmlWriter, obj);

        public static void Serialize(Type type, XmlWriter xmlWriter, object obj)
        {
            var serializer = SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
            serializer.Serialize(xmlWriter, obj);
        }

        public static T Deserialize<T>(XmlReader xmlReader) => (T) Deserialize(typeof(T), xmlReader);

        public static object Deserialize(Type type, XmlReader xmlReader)
        {
            if (xmlReader is null) return default(Type);
            var serializer = SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
            return serializer.Deserialize(xmlReader);
        }

        #endregion
    }
}