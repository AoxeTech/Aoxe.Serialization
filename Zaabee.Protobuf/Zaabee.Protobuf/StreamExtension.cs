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

        public static async Task PackByAsync<T>(this Stream stream, T obj) =>
            await ProtobufHelper.PackAsync(obj, stream);

        public static async Task<T> UnpackAsync<T>(this Stream stream) =>
            await ProtobufHelper.UnpackAsync<T>(stream);

        public static async Task<object> UnpackAsync(this Stream stream, Type type) =>
            await ProtobufHelper.UnpackAsync(type, stream);
    }
}