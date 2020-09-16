using System;
using ZeroFormatter;

namespace Zaabee.ZeroFormatter
{
    public static partial class ZeroSerializer
    {
        public static byte[] Serialize<T>(T t) =>
            ZeroFormatterSerializer.Serialize(t);

        public static byte[] Serialize(Type type, object obj) =>
            ZeroFormatterSerializer.NonGeneric.Serialize(type, obj);

        public static T Deserialize<T>(byte[] bytes) =>
            ZeroFormatterSerializer.Deserialize<T>(bytes);

        public static object Deserialize(Type type, byte[] bytes) =>
            ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes);
    }
}