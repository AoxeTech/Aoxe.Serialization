using System;
using System.IO;
using System.Threading.Tasks;

namespace Zaabee.Xml
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes<T>(this T t) =>
            XmlHelper.Serialize(t);

        public static Stream Pack<T>(this T t) =>
            XmlHelper.Pack(t);

        public static string ToXml<T>(this T t) =>
            XmlHelper.SerializeToXml(t);

        public static void PackTo<T>(this T t, Stream stream) =>
            XmlHelper.Pack(t, stream);

        public static byte[] ToBytes(this object obj, Type type) =>
            XmlHelper.Serialize(type, obj);

        public static Stream Pack(this object obj, Type type) =>
            XmlHelper.Pack(type, obj);

        public static string ToXml(this object obj, Type type) =>
            XmlHelper.SerializeToXml(type, obj);

        public static void PackTo(this object obj, Type type, Stream stream) =>
            XmlHelper.Pack(type, obj, stream);

        public static async Task<byte[]> ToBytesAsync<T>(this T t) =>
            await XmlHelper.SerializeAsync(t);

        public static async Task<Stream> PackAsync<T>(this T t) =>
            await XmlHelper.PackAsync(t);

        public static async Task<string> ToXmlAsync<T>(this T t) =>
            await XmlHelper.SerializeToXmlAsync(t);

        public static async Task PackToAsync<T>(this T t, Stream stream) =>
            await XmlHelper.PackAsync(t, stream);

        public static async Task<byte[]> ToBytesAsync(this object obj, Type type) =>
            await XmlHelper.SerializeAsync(type, obj);

        public static async Task<Stream> PackAsync(this object obj, Type type) =>
            await XmlHelper.PackAsync(type, obj);

        public static async Task<string> ToXmlAsync(this object obj, Type type) =>
            await XmlHelper.SerializeToXmlAsync(type, obj);

        public static async Task PackToAsync(this object obj, Type type, Stream stream) =>
            await XmlHelper.PackAsync(type, obj, stream);
    }
}