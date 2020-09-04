using System;
using System.IO;
using Zaabee.Extensions;

namespace Zaabee.Protobuf
{
    public static class ProtobufHelper
    {
        public static byte[] Serialize(object obj) => obj is null ? new byte[0] : ProtobufSerializer.Serialize(obj);

        public static MemoryStream Pack(object obj) => obj is null ? new MemoryStream() : ProtobufSerializer.Pack(obj);

        public static void Pack(object obj, Stream stream)
        {
            if (obj != null && stream != null)
                ProtobufSerializer.Pack(obj, stream);
        }

        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty() ? (T) typeof(T).GetDefaultValue() : ProtobufSerializer.Deserialize<T>(bytes);

        public static T Unpack<T>(Stream stream) =>
            stream.IsNullOrEmpty() ? (T) typeof(T).GetDefaultValue() : ProtobufSerializer.Unpack<T>(stream);

        public static object Deserialize(Type type, byte[] bytes) => bytes.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : ProtobufSerializer.Deserialize(type, bytes);

        public static object Unpack(Type type, Stream stream) => stream.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : ProtobufSerializer.Unpack(type, stream);
    }
}