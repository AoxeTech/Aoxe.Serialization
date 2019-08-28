using System;
using System.IO;

namespace Zaabee.Protobuf
{
    public static class StreamExtension
    {
        public static void PackProtobuf<T>(this Stream stream, T obj) =>
            ProtobufHelper.Pack(obj, stream);

        public static T UnPackProtobuf<T>(this Stream stream) =>
            ProtobufHelper.UnPack<T>(stream);

        public static object UnPackProtobuf(this Stream stream, Type type) =>
            ProtobufHelper.UnPack(type, stream);
    }
}