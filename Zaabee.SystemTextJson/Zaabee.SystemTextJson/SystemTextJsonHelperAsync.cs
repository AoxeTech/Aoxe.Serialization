using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonHelper
    {
        public static async Task PackAsync<T>(T value, Stream stream, JsonSerializerOptions options = null)
        {
            await JsonSerializer.SerializeAsync(stream, value, options ?? DefaultJsonSerializerOptions);
            if (stream.CanSeek) stream.Position = 0L;
        }

        public static async Task PackAsync(Type type, object value, Stream stream,
            JsonSerializerOptions options = null)
        {
            await JsonSerializer.SerializeAsync(stream, value, type, options ?? DefaultJsonSerializerOptions);
            if (stream.CanSeek) stream.Position = 0L;
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerOptions options = null) =>
            await JsonSerializer.DeserializeAsync<T>(stream, options ?? DefaultJsonSerializerOptions);

        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerOptions options = null) =>
            await JsonSerializer.DeserializeAsync(stream, type, options ?? DefaultJsonSerializerOptions);
    }
}