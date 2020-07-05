using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static class ZeroFormatterHelper
    {
        public static byte[] Serialize<T>(T t) => ZeroSerializer.Serialize(t);

        public static MemoryStream Pack<T>(T t) => ZeroSerializer.Pack(t);

        public static void Pack<T>(T t, Stream stream) => ZeroSerializer.Pack(t, stream);

        public static T Deserialize<T>(byte[] bytes) => ZeroSerializer.Deserialize<T>(bytes);

        public static T Unpack<T>(Stream stream) => ZeroSerializer.Unpack<T>(stream);

        public static byte[] Serialize(Type type, object obj) => ZeroSerializer.Serialize(type, obj);

        public static MemoryStream Pack(Type type, object obj) => ZeroSerializer.Pack(type, obj);

        public static void Pack(Type type, object obj, Stream stream) => ZeroSerializer.Pack(type, obj, stream);

        public static object Deserialize(Type type, byte[] bytes) => ZeroSerializer.Deserialize(type, bytes);

        public static object Unpack(Type type, Stream stream) => ZeroSerializer.Unpack(type, stream);
    }
}