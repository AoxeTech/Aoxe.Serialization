using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T t, Options options = null, Encoding encoding = null) =>
            JilHelper.Pack(t, stream, options, encoding);

        public static T Unpack<T>(this Stream stream, Options options = null, Encoding encoding = null) =>
            JilHelper.Unpack<T>(stream, options, encoding);

        public static object Unpack(this Stream stream, Type type, Options options = null, Encoding encoding = null) =>
            JilHelper.Unpack(type, stream, options, encoding);

        public static async Task PackByAsync<T>(this Stream stream, T t, Options options = null,
            Encoding encoding = null) =>
            await JilHelper.PackAsync(t, stream, options, encoding);

        public static async Task PackByAsync(this Stream stream, object obj, Options options = null,
            Encoding encoding = null) =>
            await JilHelper.PackAsync(obj, stream, options, encoding);

        public static async Task<T>
            UnpackAsync<T>(this Stream stream, Options options = null, Encoding encoding = null) =>
            await JilHelper.UnpackAsync<T>(stream, options, encoding);

        public static async Task<object> UnpackAsync(this Stream stream, Type type, Options options = null,
            Encoding encoding = null) =>
            await JilHelper.UnpackAsync(type, stream, options, encoding);
    }
}