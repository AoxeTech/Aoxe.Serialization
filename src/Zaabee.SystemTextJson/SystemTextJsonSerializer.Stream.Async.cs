using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Zaabee.Extensions;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonSerializer
    {
        public static async Task<MemoryStream> PackAsync<T>(T value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            await PackAsync(value, ms, options);
            return ms;
        }

        public static async Task<MemoryStream> PackAsync(Type type, object value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            await PackAsync(type, value, ms, options);
            return ms;
        }

        public static async Task PackAsync<T>(T value, Stream stream, JsonSerializerOptions options)
        {
            await JsonSerializer.SerializeAsync(stream, value, options);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task PackAsync(Type type, object value, Stream stream, JsonSerializerOptions options)
        {
            await JsonSerializer.SerializeAsync(stream, value, type, options);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerOptions options)
        {
            var result = await JsonSerializer.DeserializeAsync<T>(stream, options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerOptions options)
        {
            var result = await JsonSerializer.DeserializeAsync(stream, type, options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}