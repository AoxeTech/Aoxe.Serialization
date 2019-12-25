using System;
using System.IO;
using System.Threading.Tasks;

namespace Zaabee.ZeroFormatter
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T obj) =>
            ZeroFormatterHelper.Pack(obj, stream);

        public static void PackBy(this Stream stream, Type type, object obj) =>
            ZeroFormatterHelper.Pack(type, obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            ZeroFormatterHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            ZeroFormatterHelper.Unpack(type, stream);

        public static async Task PackByAsync<T>(this Stream stream, T obj) =>
            await ZeroFormatterHelper.PackAsync(obj, stream);

        public static async Task PackByAsync(this Stream stream, Type type, object obj) =>
            await ZeroFormatterHelper.PackAsync(type, obj, stream);

        public static async Task<T> UnpackAsync<T>(this Stream stream) =>
            await ZeroFormatterHelper.UnpackAsync<T>(stream);

        public static async Task<object> UnpackAsync(this Stream stream, Type type) =>
            await ZeroFormatterHelper.UnpackAsync(type, stream);
    }
}