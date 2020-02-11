using System;
using System.IO;
using ProtoBuf.Meta;

namespace Zaabee.Protobuf
{
    public static class ProtobufHelper
    {
        public static byte[] Serialize(object obj) => ProtobufSerializer.Serialize(obj);

        public static Stream Pack(object obj) => ProtobufSerializer.Pack(obj);

        public static void Pack(object obj, Stream stream) => ProtobufSerializer.Pack(obj, stream);

        public static T Deserialize<T>(byte[] bytes) => ProtobufSerializer.Deserialize<T>(bytes);

        public static T Unpack<T>(Stream stream) => ProtobufSerializer.Unpack<T>(stream);

        public static object Deserialize(Type type, byte[] bytes) => ProtobufSerializer.Deserialize(type, bytes);

        public static object Unpack(Type type, Stream stream) => ProtobufSerializer.Unpack(type, stream);
    }
}