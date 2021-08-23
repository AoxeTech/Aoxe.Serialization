using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Zaabee.Extensions;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonHelper
    {
        public static Task<MemoryStream> PackAsync<T>(T value, JsonSerializerOptions options = null) =>
            value is null
                ? Task.FromResult(new MemoryStream())
                : SystemTextJsonSerializer.PackAsync(value, options ?? DefaultJsonSerializerOptions);

        public static Task<MemoryStream> PackAsync(Type type, object value, JsonSerializerOptions options = null) =>
            value is null
                ? Task.FromResult(new MemoryStream())
                : SystemTextJsonSerializer.PackAsync(type, value, options ?? DefaultJsonSerializerOptions);

        public static Task PackAsync<T>(T value, Stream stream, JsonSerializerOptions options = null) =>
            value is null || stream is null
                ? Task.CompletedTask
                : SystemTextJsonSerializer.PackAsync(value, stream, options ?? DefaultJsonSerializerOptions);

        public static Task PackAsync(Type type, object value, Stream stream, JsonSerializerOptions options = null) =>
            value is null || stream is null
                ? Task.CompletedTask
                : SystemTextJsonSerializer.PackAsync(type, value, stream, options ?? DefaultJsonSerializerOptions);

        public static Task<T> UnpackAsync<T>(Stream stream, JsonSerializerOptions options = null) =>
            stream.IsNullOrEmpty()
                ? Task.FromResult((T)typeof(T).GetDefaultValue())
                : SystemTextJsonSerializer.UnpackAsync<T>(stream, options ?? DefaultJsonSerializerOptions);

        public static Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerOptions options = null) =>
            stream.IsNullOrEmpty()
                ? Task.FromResult(type.GetDefaultValue())
                : SystemTextJsonSerializer.UnpackAsync(type, stream, options ?? DefaultJsonSerializerOptions);
    }
}