using System;
using System.IO;
using Zaabee.Extensions;
using ZeroFormatter;

namespace Zaabee.ZeroFormatter
{
    public static partial class ZeroSerializer
    {
        public static MemoryStream Pack<T>(T t)
        {
            var ms = new MemoryStream();
            Pack(t, ms);
            return ms;
        }

        public static MemoryStream Pack(Type type, object obj)
        {
            var ms = new MemoryStream();
            Pack(type, obj, ms);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream)
        {
            ZeroFormatterSerializer.Serialize(stream, t);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static void Pack(Type type, object obj, Stream stream)
        {
            ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, obj);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream)
        {
            var result = ZeroFormatterSerializer.Deserialize<T>(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static object Unpack(Type type, Stream stream)
        {
            var result = ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}