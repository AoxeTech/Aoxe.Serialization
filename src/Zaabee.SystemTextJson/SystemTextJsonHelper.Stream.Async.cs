using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Zaabee.Extensions;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonHelper
    {
        public static async Task<MemoryStream> PackAsync<T>(T value, JsonSerializerOptions options = null) =>
            value is null
                ? new MemoryStream()
                : await SystemTextJsonSerializer.PackAsync(value, options ?? DefaultJsonSerializerOptions);

        public static async Task<MemoryStream> PackAsync(Type type, object value, JsonSerializerOptions options = null) =>
            value is null
                ? new MemoryStream()
                : await SystemTextJsonSerializer.PackAsync(type, value, options ?? DefaultJsonSerializerOptions);

        public static async Task PackAsync<T>(T value, Stream stream, JsonSerializerOptions options = null)
        {
            if (value is null || stream is null) return;
            await SystemTextJsonSerializer.PackAsync(value, stream, options ?? DefaultJsonSerializerOptions);
        }

        public static async Task PackAsync(Type type, object value, Stream stream, JsonSerializerOptions options = null)
        {
            if (value is null || stream is null) return;
            await SystemTextJsonSerializer.PackAsync(type, value, stream, options ?? DefaultJsonSerializerOptions);
        }


        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerOptions options = null) =>
            stream.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : await SystemTextJsonSerializer.UnpackAsync<T>(stream, options ?? DefaultJsonSerializerOptions);

        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerOptions options = null) =>
            stream.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : await SystemTextJsonSerializer.UnpackAsync(type, stream, options ?? DefaultJsonSerializerOptions);
    }
}