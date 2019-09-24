using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class ObjectExtension
    {
        public static string ToJson<T>(this T t, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.SerializeToJson(t, resolver);

        public static byte[] ToBytes<T>(this T t, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Serialize(t, resolver);

        public static void PackTo<T>(this T t, Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Pack(t, stream, resolver);

        public static Stream Pack<T>(this T t, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Pack(t, resolver);

        public static string ToJson(this object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.SerializeToJson(obj, resolver);

        public static string ToJson(this object obj, Type type, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.SerializeToJson(type, obj, resolver);

        public static byte[] ToBytes(this object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Serialize(obj, resolver);

        public static byte[] ToBytes(this object obj, Type type, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Serialize(type, obj, resolver);

        public static Stream Pack(this object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Pack(obj, resolver);

        public static Stream Pack(this object obj, Type type, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Pack(type, obj, resolver);

        public static void PackTo(this object obj, Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Pack(obj, stream, resolver);

        public static void PackTo(this object obj, Type type, Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Pack(type, obj, stream, resolver);

        public static async Task<string> ToJsonAsync<T>(this T t, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.SerializeToJsonAsync(t, resolver);

        public static async Task<byte[]> ToBytesAsync<T>(this T t, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.SerializeAsync(t, resolver);

        public static async Task PackToAsync<T>(this T t, Stream stream, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.PackAsync(t, stream, resolver);

        public static async Task<Stream> PackAsync<T>(this T t, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.PackAsync(t, resolver);

        public static async Task<string> ToJsonAsync(this object obj, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.SerializeToJsonAsync(obj, resolver);

        public static async Task<string>
            ToJsonAsync(this object obj, Type type, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.SerializeToJsonAsync(type, obj, resolver);

        public static async Task<byte[]> ToBytesAsync(this object obj, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.SerializeAsync(obj, resolver);

        public static async Task<byte[]> ToBytesAsync(this object obj, Type type,
            IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.SerializeAsync(type, obj, resolver);

        public static async Task<Stream> PackAsync(this object obj, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.PackAsync(obj, resolver);

        public static async Task<Stream> PackAsync(this object obj, Type type,
            IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.PackAsync(type, obj, resolver);

        public static async Task PackToAsync(this object obj, Stream stream, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.PackAsync(obj, stream, resolver);

        public static async Task PackToAsync(this object obj, Type type, Stream stream,
            IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.PackAsync(type, obj, stream, resolver);
    }
}