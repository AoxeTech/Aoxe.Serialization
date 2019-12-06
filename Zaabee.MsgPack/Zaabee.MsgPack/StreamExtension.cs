using System;
using System.IO;
using System.Threading.Tasks;

namespace Zaabee.MsgPack
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T obj) =>
            MsgPackHelper.Pack(obj, stream);

        public static void PackBy(this Stream stream, Type type, object obj) =>
            MsgPackHelper.Pack(type, obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            MsgPackHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            MsgPackHelper.Unpack(type, stream);

        public static async Task PackByAsync<T>(this Stream stream, T obj) =>
            await MsgPackHelper.PackAsync(obj, stream);

        public static async Task<T> UnpackAsync<T>(this Stream stream) =>
            await MsgPackHelper.UnpackAsync<T>(stream);
    }
}