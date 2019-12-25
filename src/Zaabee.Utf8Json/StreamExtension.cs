using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Pack(obj, stream, resolver);

        public static void PackBy(this Stream stream, Type type, object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Pack(type, obj, stream, resolver);

        public static T Unpack<T>(this Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Unpack<T>(stream, resolver);

        public static object Unpack(this Stream stream, Type type, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Unpack(type, stream, resolver);

        public static async Task PackByAsync<T>(this Stream stream, T obj, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.PackAsync(obj, stream, resolver);

        public static async Task PackByAsync(this Stream stream, Type type, object obj,
            IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.PackAsync(type, obj, stream, resolver);

        public static async Task<T> UnpackAsync<T>(this Stream stream, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.UnpackAsync<T>(stream, resolver);

        public static async Task<object> UnpackAsync(this Stream stream, Type type,
            IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.UnpackAsync(type, stream, resolver);
    }
}