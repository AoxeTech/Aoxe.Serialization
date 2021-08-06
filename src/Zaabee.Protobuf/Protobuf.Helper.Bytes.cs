using System;
using Zaabee.Extensions;

namespace Zaabee.Protobuf
{
    public static partial class ProtobufHelper
    {
        public static byte[] Serialize<T>(T t) =>
            t is null
                ? Array.Empty<byte>()
                : ProtobufSerializer.Serialize(t);

        public static byte[] Serialize(object obj) =>
            obj is null
                ? Array.Empty<byte>()
                : ProtobufSerializer.Serialize(obj);

        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : ProtobufSerializer.Deserialize<T>(bytes);

        public static object Deserialize(Type type, byte[] bytes) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : ProtobufSerializer.Deserialize(type, bytes);
    }
}