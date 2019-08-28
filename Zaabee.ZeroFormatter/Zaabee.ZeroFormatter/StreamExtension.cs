using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static class StreamExtension
    {
        public static void PackByZeroFormatter<T>(this Stream stream, T obj) =>
            ZeroFormatterHelper.Pack(obj, stream);

        public static void PackByZeroFormatter(this Stream stream, Type type, object obj) =>
            ZeroFormatterHelper.Pack(type, obj, stream);

        public static T UnPackByZeroFormatter<T>(this Stream stream) =>
            ZeroFormatterHelper.UnPack<T>(stream);

        public static object UnPackByZeroFormatter(this Stream stream, Type type) =>
            ZeroFormatterHelper.UnPack(type, stream);
    }
}