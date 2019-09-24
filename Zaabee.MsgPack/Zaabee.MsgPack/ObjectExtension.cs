using System;
using System.IO;
using System.Threading.Tasks;

namespace Zaabee.MsgPack
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes<T>(this T t) =>
            MsgPackHelper.Serialize(t);

        public static Stream ToStream<T>(this T t) =>
            MsgPackHelper.Pack(t);

        public static void PackTo<T>(this T t, Stream stream) =>
            MsgPackHelper.Pack(t, stream);

        public static byte[] ToBytes(this object obj, Type type) =>
            MsgPackHelper.Serialize(type, obj);

        public static Stream ToStream(this object obj, Type type) =>
            MsgPackHelper.Pack(type, obj);

        public static void PackTo(this object obj, Type type, Stream stream) =>
            MsgPackHelper.Pack(type, obj, stream);

        public static async Task<byte[]> ToBytesAsync<T>(this T t) =>
            await MsgPackHelper.SerializeAsync(t);

        public static async Task<Stream> ToStreamAsync<T>(this T t) =>
            await MsgPackHelper.PackAsync(t);

        public static async Task PackToAsync<T>(this T t, Stream stream) =>
            await MsgPackHelper.PackAsync(t, stream);

        public static async Task<byte[]> ToBytesAsync(this object obj, Type type) =>
            await MsgPackHelper.SerializeAsync(type, obj);

        public static async Task<Stream> ToStreamAsync(this object obj, Type type) =>
            await MsgPackHelper.PackAsync(type, obj);

        public static async Task PackToAsync(this object obj, Type type, Stream stream) =>
            await MsgPackHelper.PackAsync(type, obj, stream);
    }
}