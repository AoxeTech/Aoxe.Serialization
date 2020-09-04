using System;
using System.IO;
using Zaabee.Extensions;

namespace Zaabee.ZeroFormatter
{
    public static class ZeroFormatterHelper
    {
        public static byte[] Serialize<T>(T t) => t is null ? new byte[0] : ZeroSerializer.Serialize(t);

        public static MemoryStream Pack<T>(T t) => t is null ? new MemoryStream() : ZeroSerializer.Pack(t);

        public static void Pack<T>(T t, Stream stream)
        {
            if (t is null || stream is null) return;
            ZeroSerializer.Pack(t, stream);
        }

        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : ZeroSerializer.Deserialize<T>(bytes);

        public static T Unpack<T>(Stream stream) =>
            stream is null ? (T) typeof(T).GetDefaultValue() : ZeroSerializer.Unpack<T>(stream);

        public static byte[] Serialize(Type type, object obj) =>
            obj is null ? new byte[0] : ZeroSerializer.Serialize(type, obj);

        public static MemoryStream Pack(Type type, object obj) =>
            obj is null ? new MemoryStream() : ZeroSerializer.Pack(type, obj);

        public static void Pack(Type type, object obj, Stream stream)
        {
            if (obj is null || stream is null) return;
            ZeroSerializer.Pack(type, obj, stream);
        }

        public static object Deserialize(Type type, byte[] bytes) => bytes.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : ZeroSerializer.Deserialize(type, bytes);

        public static object Unpack(Type type, Stream stream) =>
            stream is null ? type.GetDefaultValue() : ZeroSerializer.Unpack(type, stream);
    }
}