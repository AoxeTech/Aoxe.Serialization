using System;
using System.IO;

namespace Zaabee.Xml
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes<T>(this T t) => XmlHelper.Serialize(t);

        public static Stream Pack<T>(this T t) => XmlHelper.Pack(t);

        public static string ToXml<T>(this T t) => XmlHelper.SerializeToXml(t);

        public static void PackTo<T>(this T t, Stream stream) => XmlHelper.Pack(t, stream);

        public static byte[] ToBytes(this object obj, Type type) => XmlHelper.Serialize(type, obj);

        public static Stream Pack(this object obj, Type type) => XmlHelper.Pack(type, obj);

        public static string ToXml(this object obj, Type type) => XmlHelper.SerializeToXml(type, obj);

        public static void PackTo(this object obj, Type type, Stream stream) => XmlHelper.Pack(type, obj, stream);
    }
}