using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static class StreamExtension
    {
        public static void PackByZeroFormatter<T>(this Stream stream, T obj) =>
            ZeroFormatterHelper.Serialize(stream, obj);

        public static void PackByZeroFormatter(this Stream stream, object obj, Type type) =>
            ZeroFormatterHelper.Serialize(type, stream, obj);

        public static T UnPackByZeroFormatter<T>(this Stream stream) =>
            ZeroFormatterHelper.Deserialize<T>(stream);

        public static object UnPackByZeroFormatter(this Stream stream, Type type) =>
            ZeroFormatterHelper.Deserialize(type, stream);
    }
}