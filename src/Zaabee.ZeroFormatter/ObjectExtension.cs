using System;
using System.IO;
using System.Threading.Tasks;

namespace Zaabee.ZeroFormatter
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes<T>(this T t) =>
            ZeroFormatterHelper.Serialize(t);

        public static Stream ToStream<T>(this T t) =>
            ZeroFormatterHelper.Pack(t);

        public static void PackTo<T>(this T t, Stream stream) =>
            ZeroFormatterHelper.Pack(t, stream);

        public static byte[] ToBytes(this object obj, Type type) =>
            ZeroFormatterHelper.Serialize(type, obj);

        public static Stream ToStream(this object obj, Type type) =>
            ZeroFormatterHelper.Pack(type, obj);

        public static void PackTo(this object obj, Type type, Stream stream) =>
            ZeroFormatterHelper.Pack(type, obj, stream);

        public static async Task<byte[]> ToBytesAsync<T>(this T t) =>
            await ZeroFormatterHelper.SerializeAsync(t);

        public static async Task<Stream> ToStreamAsync<T>(this T t) =>
            await ZeroFormatterHelper.PackAsync(t);

        public static async Task PackToAsync<T>(this T t, Stream stream) =>
            await ZeroFormatterHelper.PackAsync(t, stream);

        public static async Task<byte[]> ToBytesAsync(this object obj, Type type) =>
            await ZeroFormatterHelper.SerializeAsync(type, obj);

        public static async Task<Stream> ToStreamAsync(this object obj, Type type) =>
            await ZeroFormatterHelper.PackAsync(type, obj);

        public static async Task PackToAsync(this object obj, Type type, Stream stream) =>
            await ZeroFormatterHelper.PackAsync(type, obj, stream);
    }
}