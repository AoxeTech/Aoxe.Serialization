using System;
using System.IO;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T t, Options options = null) =>
            JilHelper.Pack(t, stream, options);

        public static T Unpack<T>(this Stream stream, Options options = null) =>
            JilHelper.Unpack<T>(stream, options);

        public static object Unpack(this Stream stream, Type type, Options options = null) =>
            JilHelper.Unpack(type, stream, options);

        public static async Task PackByAsync<T>(this Stream stream, T t, Options options = null) =>
            await JilHelper.PackAsync(t, stream, options);

        public static async Task PackByAsync(this Stream stream, object obj, Options options = null) =>
            await JilHelper.PackAsync(obj, stream, options);

        public static async Task<T> UnpackAsync<T>(this Stream stream, Options options = null) =>
            await JilHelper.UnpackAsync<T>(stream, options);

        public static async Task<object> UnpackAsync(this Stream stream, Type type, Options options = null) =>
            await JilHelper.UnpackAsync(type, stream, options);
    }
}