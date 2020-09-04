using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zaabee.SystemTextJson
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T obj, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Pack(obj, stream, options);

        public static void PackBy(this Stream stream, Type type, object obj, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Pack(type, obj, stream, options);

        public static T Unpack<T>(this Stream stream, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Unpack<T>(stream, options);

        public static object Unpack(this Stream stream, Type type, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Unpack(type, stream, options);

        public static async Task PackByAsync<T>(this Stream stream, T obj, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.PackAsync(obj, stream, options);

        public static async Task PackByAsync(this Stream stream, Type type, object obj, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.PackAsync(type, obj, stream, options);

        public static async Task<T> UnpackAsync<T>(this Stream stream, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.UnpackAsync<T>(stream, options);

        public static async Task<object> UnpackAsync(this Stream stream, Type type,
            JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.UnpackAsync(type, stream, options);
    }
}