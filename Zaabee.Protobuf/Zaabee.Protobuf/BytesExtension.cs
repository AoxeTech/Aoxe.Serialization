using System;

namespace Zaabee.Protobuf
{
    public static class BytesExtension
    {
        public static T FromProtobuf<T>(this byte[] bytes) =>
            ProtobufHelper.Deserialize<T>(bytes);

        public static object FromProtobuf(this byte[] bytes, Type type) =>
            ProtobufHelper.Deserialize(type, bytes);
    }
}