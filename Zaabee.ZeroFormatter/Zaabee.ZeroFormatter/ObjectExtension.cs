using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static class ObjectExtension
    {
        public static byte[] ToZeroFormatter<T>(this T t) =>
            ZeroFormatterHelper.Serialize(t);

        public static Stream PackZeroFormatter<T>(this T t) =>
            ZeroFormatterHelper.Pack(t);

        public static void PackZeroFormatter<T>(this T t, Stream stream) =>
            ZeroFormatterHelper.Pack(t, stream);

        public static byte[] ToZeroFormatter(this object obj, Type type) =>
            ZeroFormatterHelper.Serialize(type, obj);

        public static Stream PackZeroFormatter(this object obj, Type type) =>
            ZeroFormatterHelper.Pack(type, obj);

        public static void PackZeroFormatter(this object obj, Type type, Stream stream) =>
            ZeroFormatterHelper.Pack(type, obj, stream);
    }
}