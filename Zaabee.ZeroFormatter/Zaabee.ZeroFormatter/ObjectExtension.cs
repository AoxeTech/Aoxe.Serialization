using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToZeroFormatter<T>(this T obj) =>
            ZeroFormatterHelper.Serialize(obj);

        public static void PackByZeroFormatter<T>(this T obj, Stream stream) =>
            ZeroFormatterHelper.Serialize(stream, obj);

        public static byte[] ToZeroFormatter(this object obj, Type type) =>
            ZeroFormatterHelper.Serialize(type, obj);

        public static void PackByZeroFormatter(this object obj, Stream stream, Type type) =>
            ZeroFormatterHelper.Serialize(type, stream, obj);
    }
}