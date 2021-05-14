using System;
using Zaabee.Extensions;

namespace Zaabee.ZeroFormatter
{
    public static partial class ZeroFormatterHelper
    {
        public static byte[] Serialize<T>(T t) => t is null ? new byte[0] : ZeroSerializer.Serialize(t);

        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : ZeroSerializer.Deserialize<T>(bytes);

        public static byte[] Serialize(Type type, object obj) =>
            obj is null ? new byte[0] : ZeroSerializer.Serialize(type, obj);

        public static object Deserialize(Type type, byte[] bytes) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : ZeroSerializer.Deserialize(type, bytes);
    }
}