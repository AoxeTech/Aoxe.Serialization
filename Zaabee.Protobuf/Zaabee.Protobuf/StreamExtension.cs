using System;
using System.IO;
using System.Threading.Tasks;

namespace Zaabee.Protobuf
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T obj) =>
            ProtobufHelper.Pack(obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            ProtobufHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            ProtobufHelper.Unpack(type, stream);
    }
}