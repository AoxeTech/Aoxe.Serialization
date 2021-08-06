using System;
using Zaabee.Extensions;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackHelper
    {
        public static byte[] Serialize<T>(T t) =>
            t is null
                ? Array.Empty<byte>()
                : MsgPackSerializer.Serialize(t);

        public static byte[] Serialize(Type type, object obj) =>
            obj is null
                ? Array.Empty<byte>()
                : MsgPackSerializer.Serialize(type, obj);

        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : MsgPackSerializer.Deserialize<T>(bytes);

        public static object Deserialize(Type type, byte[] bytes) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : MsgPackSerializer.Deserialize(type, bytes);
    }
}