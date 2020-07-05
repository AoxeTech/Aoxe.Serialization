using System;
using System.IO;
using System.Text;
using System.Xml;

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
            XmlSerializer.Pack(t);

        public static void Pack<T>(T t, Stream stream) =>
            XmlSerializer.Pack(t, stream);

        public static string SerializeToXml<T>(T t, Encoding encoding = null) =>
            XmlSerializer.SerializeToXml(t, encoding ?? DefaultEncoding);

        public static byte[] Serialize(Type type, object obj) =>
            XmlSerializer.Serialize(type, obj);

        public static MemoryStream Pack(Type type, object obj) =>
            XmlSerializer.Pack(type, obj);

        public static void Pack(Type type, object obj, Stream stream) =>
            XmlSerializer.Pack(type, obj, stream);

        public static string SerializeToXml(Type type, object obj, Encoding encoding = null) =>
            XmlSerializer.SerializeToXml(type, obj, encoding ?? DefaultEncoding);

        public static T Deserialize<T>(byte[] bytes) =>
            XmlSerializer.Deserialize<T>(bytes);

        public static T Unpack<T>(Stream stream) =>
            XmlSerializer.Unpack<T>(stream);

        public static T Deserialize<T>(string xml, Encoding encoding = null) =>
            XmlSerializer.Deserialize<T>(xml, encoding ?? DefaultEncoding);

        public static object Deserialize(Type type, byte[] bytes) =>
            XmlSerializer.Deserialize(type, bytes);

        public static object Unpack(Type type, Stream stream) =>
            XmlSerializer.Unpack(type, stream);

        public static object Deserialize(Type type, string xml, Encoding encoding = null) =>
            XmlSerializer.Deserialize(type, xml, encoding ?? DefaultEncoding);

        public static void Serialize<T>(TextWriter textWriter, T t) =>
            XmlSerializer.Serialize<T>(textWriter, t);

        public static void Serialize(Type type, TextWriter textWriter, object obj) =>
            XmlSerializer.Serialize(type, textWriter, obj);

        public static T Deserialize<T>(TextReader textReader) =>
            XmlSerializer.Deserialize<T>(textReader);

        public static object Deserialize(Type type, TextReader textReader) =>
            XmlSerializer.Deserialize(type, textReader);

        public static void Serialize<T>(XmlWriter xmlWriter, T t) =>
            XmlSerializer.Serialize<T>(xmlWriter, t);

        public static void Serialize(Type type, XmlWriter xmlWriter, object obj) =>
            XmlSerializer.Serialize(type, xmlWriter, obj);

        public static T Deserialize<T>(XmlReader xmlReader) =>
            XmlSerializer.Deserialize<T>(xmlReader);

        public static object Deserialize(Type type, XmlReader xmlReader) =>
            XmlSerializer.Deserialize(type, xmlReader);
    }
}