using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonHelper
    {
        public static async Task PackAsync<T>(T value, Stream stream, JsonSerializerOptions options = null) =>
            await SystemTextJsonSerializer.PackAsync(value, stream, options ?? DefaultJsonSerializerOptions);

        public static async Task PackAsync(Type type, object value, Stream stream,
            JsonSerializerOptions options = null) =>
            await SystemTextJsonSerializer.PackAsync(type, value, stream, options ?? DefaultJsonSerializerOptions);

        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerOptions options = null) =>
            await SystemTextJsonSerializer.UnpackAsync<T>(stream, options ?? DefaultJsonSerializerOptions);

        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerOptions options = null) =>
            await SystemTextJsonSerializer.UnpackAsync(type, stream, options ?? DefaultJsonSerializerOptions);
    }
}