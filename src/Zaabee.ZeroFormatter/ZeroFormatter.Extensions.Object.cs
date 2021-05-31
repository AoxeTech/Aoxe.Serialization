using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static partial class ZeroFormatterExtensions
    {
        public static byte[] ToBytes<T>(this T t) =>
            ZeroFormatterHelper.Serialize(t);

        public static byte[] ToBytes(this object obj, Type type) =>
            ZeroFormatterHelper.Serialize(type, obj);

        public static MemoryStream ToStream<T>(this T t) =>
            ZeroFormatterHelper.Pack(t);

        public static MemoryStream ToStream(this object obj, Type type) =>
            ZeroFormatterHelper.Pack(type, obj);

        public static void PackTo<T>(this T t, Stream stream) =>
            ZeroFormatterHelper.Pack(t, stream);

        public static void PackTo(this object obj, Type type, Stream stream) =>
            ZeroFormatterHelper.Pack(type, obj, stream);
    }
}