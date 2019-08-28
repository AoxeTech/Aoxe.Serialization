using System;
using System.IO;
using ZeroFormatter;

namespace Zaabee.ZeroFormatter
{
    public static class ZeroFormatterHelper
    {
        public static byte[] Serialize<T>(T t) =>
            t is null ? new byte[0] : ZeroFormatterSerializer.Serialize(t);

        public static Stream Pack<T>(T t)
        {
            var ms = new MemoryStream();
            if (t is null) return ms;
            ZeroFormatterSerializer.Serialize(ms, t);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream)
        {
            if (t != null) ZeroFormatterSerializer.Serialize(stream, t);
        }

        public static byte[] Serialize(Type type, object obj) =>
            obj is null ? new byte[0] : ZeroFormatterSerializer.NonGeneric.Serialize(type, obj);

        public static Stream Pack(Type type, object obj)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            ZeroFormatterSerializer.NonGeneric.Serialize(type, ms, obj);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream)
        {
            if (obj != null) ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, obj);
        }

        public static T Deserialize<T>(byte[] bytes) =>
            bytes is null || bytes.Length == 0 ? default(T) : ZeroFormatterSerializer.Deserialize<T>(bytes);

        public static T Unpack<T>(Stream stream) =>
            stream is null ? default(T) : ZeroFormatterSerializer.Deserialize<T>(stream);

        public static object Deserialize(Type type, byte[] bytes) =>
            bytes is null || bytes.Length == 0 ? null : ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes);

        public static object Unpack(Type type, Stream stream) =>
            stream is null ? null : ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream);
    }
}