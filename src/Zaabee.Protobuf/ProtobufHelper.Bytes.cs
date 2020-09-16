using System;
using Zaabee.Extensions;

namespace Zaabee.Protobuf
{
    public static partial class ProtobufHelper
    {
        public static byte[] Serialize(object obj) =>
            obj is null
                ? new byte[0]
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