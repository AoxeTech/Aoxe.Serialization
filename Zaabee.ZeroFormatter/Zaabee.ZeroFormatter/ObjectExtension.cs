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
        public static byte[] Serialize<T>(this T t) =>
            ZeroFormatterHelper.Serialize(t);

        public static Stream Pack<T>(this T t) =>
            ZeroFormatterHelper.Pack(t);

        public static void Pack<T>(this T t, Stream stream) =>
            ZeroFormatterHelper.Pack(t, stream);

        public static byte[] Serialize(this object obj, Type type) =>
            ZeroFormatterHelper.Serialize(type, obj);

        public static Stream Pack(this object obj, Type type) =>
            ZeroFormatterHelper.Pack(type, obj);

        public static void Pack(this object obj, Type type, Stream stream) =>
            ZeroFormatterHelper.Pack(type, obj, stream);
    }
}