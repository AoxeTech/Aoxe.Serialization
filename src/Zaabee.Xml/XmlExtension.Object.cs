using System;
using System.IO;
using System.Xml;

namespace Zaabee.Xml
{
    public static partial class XmlExtension
    {
        public static byte[] ToBytes<T>(this T t) => XmlHelper.Serialize(t);

        public static byte[] ToBytes(this object obj, Type type) => XmlHelper.Serialize(type, obj);

        public static MemoryStream ToStream<T>(this T t) => XmlHelper.Pack(t);

        public static void PackTo<T>(this T t, Stream stream) => XmlHelper.Pack(t, stream);

        public static void PackTo(this object obj, Type type, Stream stream) => XmlHelper.Pack(type, obj, stream);

        public static MemoryStream Pack(this object obj, Type type) => XmlHelper.Pack(type, obj);

        public static string ToXml<T>(this T t) => XmlHelper.SerializeToXml(t);

        public static string ToXml(this object obj, Type type) => XmlHelper.SerializeToXml(type, obj);

        public static void ToXml<T>(this T t, TextWriter textWriter) => XmlHelper.Serialize(textWriter, t);

        public static void ToXml(this object obj, Type type, TextWriter textWriter) =>
            XmlHelper.Serialize(type, textWriter, obj);

        public static void ToXml<T>(this T t, XmlWriter xmlWriter) => XmlHelper.Serialize(xmlWriter, t);

        public static void ToXml(this object obj, Type type, XmlWriter xmlWriter) =>
            XmlHelper.Serialize(type, xmlWriter, obj);
    }
}