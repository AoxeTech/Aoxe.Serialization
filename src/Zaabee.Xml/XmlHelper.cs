using System;
using System.IO;
using System.Text;
using System.Xml;
using Zaabee.Extensions;

namespace Zaabee.Xml
{
    public static class XmlHelper
    {
        private static Encoding _encoding = Encoding.UTF8;

        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        public static byte[] Serialize<T>(T t) =>
            XmlSerializer.Serialize(t);

        public static MemoryStream Pack<T>(T t) =>
            t is null ? new MemoryStream() : XmlSerializer.Pack(t);

        public static void Pack<T>(T t, Stream stream)
        {
            if (t is null || stream is null) return;
            XmlSerializer.Pack(t, stream);
        }

        public static string SerializeToXml<T>(T t, Encoding encoding = null) =>
            XmlSerializer.SerializeToXml(t, encoding ?? DefaultEncoding);

        public static byte[] Serialize(Type type, object obj) =>
            obj is null ? new byte[0] : XmlSerializer.Serialize(type, obj);

        public static MemoryStream Pack(Type type, object obj) =>
            obj is null ? new MemoryStream() : XmlSerializer.Pack(type, obj);

        public static void Pack(Type type, object obj, Stream stream)
        {
            if (type is null || obj is null || stream is null) return;
            XmlSerializer.Pack(type, obj, stream);
        }

        public static string SerializeToXml(Type type, object obj, Encoding encoding = null) =>
            XmlSerializer.SerializeToXml(type, obj, encoding ?? DefaultEncoding);

        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty() ? (T) typeof(T).GetDefaultValue() : XmlSerializer.Deserialize<T>(bytes);

        public static T Unpack<T>(Stream stream) =>
            stream.IsNullOrEmpty() ? (T) typeof(T).GetDefaultValue() : XmlSerializer.Unpack<T>(stream);

        public static T Deserialize<T>(string xml, Encoding encoding = null) =>
            xml.IsNullOrWhiteSpace()
                ? (T) typeof(T).GetDefaultValue()
                : XmlSerializer.Deserialize<T>(xml, encoding ?? DefaultEncoding);

        public static object Deserialize(Type type, byte[] bytes) =>
            bytes.IsNullOrEmpty() ? type.GetDefaultValue() : XmlSerializer.Deserialize(type, bytes);

        public static object Unpack(Type type, Stream stream) =>
            type is null || stream.IsNullOrEmpty() ? null : XmlSerializer.Unpack(type, stream);

        public static object Deserialize(Type type, string xml, Encoding encoding = null) =>
            type is null || xml.IsNullOrWhiteSpace()
                ? null
                : XmlSerializer.Deserialize(type, xml, encoding ?? DefaultEncoding);

        public static void Serialize<T>(TextWriter textWriter, T t)
        {
            if (textWriter is null || t is null) return;
            XmlSerializer.Serialize<T>(textWriter, t);
        }

        public static void Serialize(Type type, TextWriter textWriter, object obj)
        {
            if (type is null || textWriter is null || obj is null) return;
            XmlSerializer.Serialize(type, textWriter, obj);
        }

        public static T Deserialize<T>(TextReader textReader) =>
            textReader is null ? (T) typeof(T).GetDefaultValue() : XmlSerializer.Deserialize<T>(textReader);

        public static object Deserialize(Type type, TextReader textReader) =>
            type is null || textReader is null ? null : XmlSerializer.Deserialize(type, textReader);

        public static void Serialize<T>(XmlWriter xmlWriter, T t) =>
            XmlSerializer.Serialize<T>(xmlWriter, t);

        public static void Serialize(Type type, XmlWriter xmlWriter, object obj) =>
            XmlSerializer.Serialize(type, xmlWriter, obj);

        public static T Deserialize<T>(XmlReader xmlReader) =>
            xmlReader is null ? (T) typeof(T).GetDefaultValue() : XmlSerializer.Deserialize<T>(xmlReader);

        public static object Deserialize(Type type, XmlReader xmlReader) =>
            type is null || xmlReader is null ? null : XmlSerializer.Deserialize(type, xmlReader);
    }
}