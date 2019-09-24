using System;
using System.IO;
using System.Threading.Tasks;

namespace Zaabee.Xml
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T t) =>
            XmlHelper.Pack(t, stream);

        public static void PackBy(this Stream stream, Type type, object obj) =>
            XmlHelper.Pack(type, obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            XmlHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            XmlHelper.Unpack(type, stream);

        public static async Task PackByAsync<T>(this Stream stream, T t) =>
            await XmlHelper.PackAsync(t, stream);

        public static async Task PackByAsync(this Stream stream, Type type, object obj) =>
            await XmlHelper.PackAsync(type, obj, stream);

        public static async Task<T> UnpackAsync<T>(this Stream stream) =>
            await XmlHelper.UnpackAsync<T>(stream);

        public static async Task<object> UnpackAsync(this Stream stream, Type type) =>
            await XmlHelper.UnpackAsync(type, stream);
    }
}