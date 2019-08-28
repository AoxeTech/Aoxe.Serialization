using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static class StreamExtension
    {
        public static void Pack<T>(this Stream stream, T obj) =>
            ZeroFormatterHelper.Pack(obj, stream);

        public static void Pack(this Stream stream, Type type, object obj) =>
            ZeroFormatterHelper.Pack(type, obj, stream);

        public static T UnPack<T>(this Stream stream) =>
            ZeroFormatterHelper.UnPack<T>(stream);

        public static object UnPack(this Stream stream, Type type) =>
            ZeroFormatterHelper.UnPack(type, stream);
    }
}