using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static partial class ZeroFormatterExtension
    {
        public static void PackBy<T>(this Stream stream, T obj) =>
            ZeroFormatterHelper.Pack(obj, stream);

        public static void PackBy(this Stream stream, Type type, object obj) =>
            ZeroFormatterHelper.Pack(type, obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            ZeroFormatterHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            ZeroFormatterHelper.Unpack(type, stream);
    }
}