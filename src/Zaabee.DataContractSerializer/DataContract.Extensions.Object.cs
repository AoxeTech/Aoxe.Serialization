using System;
using System.IO;
using System.Xml;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractExtensions
    {
        public static byte[] ToBytes<T>(this T t) => DataContractHelper.Serialize(t);

        public static byte[] ToBytes(this object obj, Type type) => DataContractHelper.Serialize(type, obj);

        public static MemoryStream ToStream<T>(this T t) => DataContractHelper.Pack(t);

        public static void PackTo<T>(this T t, Stream stream) => DataContractHelper.Pack(t, stream);

        public static void PackTo(this object obj, Type type, Stream stream) => DataContractHelper.Pack(type, obj, stream);

        public static MemoryStream Pack(this object obj, Type type) => DataContractHelper.Pack(type, obj);

        public static string ToXml<T>(this T t) => DataContractHelper.SerializeToXml(t);

        public static string ToXml(this object obj, Type type) => DataContractHelper.SerializeToXml(type, obj);

        public static void ToXml<T>(this T t, XmlWriter xmlWriter) => DataContractHelper.Serialize(xmlWriter, t);

        public static void ToXml(this object obj, Type type, XmlWriter xmlWriter) =>
            DataContractHelper.Serialize(type, xmlWriter, obj);
    }
}