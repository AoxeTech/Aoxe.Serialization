using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zaabee.SystemTextJson
{
    public static class ObjectExtension
    {
        public static string ToJson<T>(this T t, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.SerializeToJson(t, options);

        public static byte[] ToBytes<T>(this T t, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Serialize(t, options);

        public static void PackTo<T>(this T t, Stream stream, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Pack(t, stream, options);

        public static Stream Pack<T>(this T t, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Pack(t, options);

        public static string ToJson(this object obj, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.SerializeToJson(obj, options);

        public static string ToJson(this object obj, Type type, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.SerializeToJson(type, obj, options);

        public static byte[] ToBytes(this object obj, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Serialize(obj, options);

        public static byte[] ToBytes(this object obj, Type type, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Serialize(type, obj, options);

        public static Stream Pack(this object obj, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Pack(obj, options);

        public static Stream Pack(this object obj, Type type, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Pack(type, obj, options);

        public static void PackTo(this object obj, Stream stream, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Pack(obj, stream, options);

        public static void PackTo(this object obj, Type type, Stream stream, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Pack(type, obj, stream, options);

        public static async Task<string> ToJsonAsync<T>(this T t, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.SerializeToJsonAsync(t, options);

        public static async Task<byte[]> ToBytesAsync<T>(this T t, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.SerializeAsync(t, options);

        public static async Task PackToAsync<T>(this T t, Stream stream, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.PackAsync(t, stream, options);

        public static async Task<Stream> PackAsync<T>(this T t, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.PackAsync(t, options);

        public static async Task<string> ToJsonAsync(this object obj, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.SerializeToJsonAsync(obj, options);

        public static async Task<string>
            ToJsonAsync(this object obj, Type type, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.SerializeToJsonAsync(type, obj, options);

        public static async Task<byte[]> ToBytesAsync(this object obj, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.SerializeAsync(obj, options);

        public static async Task<byte[]> ToBytesAsync(this object obj, Type type,
            JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.SerializeAsync(type, obj, options);

        public static async Task<Stream> PackAsync(this object obj, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.PackAsync(obj, options);

        public static async Task<Stream> PackAsync(this object obj, Type type,
            JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.PackAsync(type, obj, options);

        public static async Task PackToAsync(this object obj, Stream stream, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.PackAsync(obj, stream, options);

        public static async Task PackToAsync(this object obj, Type type, Stream stream,
            JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.PackAsync(type, obj, stream, options);
    }
}