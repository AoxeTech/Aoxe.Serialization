using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to bytes
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static byte[] SerializeByZeroFormatter<T>(this T t) =>
            ZeroFormatterHelper.Serialize(t);

        public static Stream PackByZeroFormatter<T>(this T t) =>
            ZeroFormatterHelper.Pack(t);

        public static void PackByZeroFormatter<T>(this T t, Stream stream) =>
            ZeroFormatterHelper.Pack(t, stream);

        public static byte[] SerializeByZeroFormatter(this object obj, Type type) =>
            ZeroFormatterHelper.Serialize(type, obj);

        public static Stream PackByZeroFormatter(this object obj, Type type) =>
            ZeroFormatterHelper.Pack(type, obj);

        public static void PackByZeroFormatter(this object obj, Type type, Stream stream) =>
            ZeroFormatterHelper.Pack(type, obj, stream);
    }
}