using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static class StreamExtension
    {
        public static void PackZeroFormatter<T>(this Stream stream, T obj) =>
            ZeroFormatterHelper.Pack(obj, stream);

        public static void PackZeroFormatter(this Stream stream, Type type, object obj) =>
            ZeroFormatterHelper.Pack(type, obj, stream);

        public static T UnPackZeroFormatter<T>(this Stream stream) =>
            ZeroFormatterHelper.UnPack<T>(stream);

        public static object UnPackZeroFormatter(this Stream stream, Type type) =>
            ZeroFormatterHelper.UnPack(type, stream);
    }
}