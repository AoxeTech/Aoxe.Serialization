using System;
using System.IO;

namespace Zaabee.Protobuf
{
    public static class StreamExtension
    {
        public static void PackProtobuf<T>(this Stream stream, T obj) =>
            ProtobufHelper.Pack(obj, stream);

        public static T UnpackProtobuf<T>(this Stream stream) =>
            ProtobufHelper.Unpack<T>(stream);

        public static object UnpackProtobuf(this Stream stream, Type type) =>
            ProtobufHelper.Unpack(type, stream);
    }
}