using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;
using Zaabee.Extensions;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonHelper
    {
        public static Task PackAsync<T>(T value, Stream stream, IJsonFormatterResolver resolver = null) =>
            value is null || stream is null
                ? Task.CompletedTask
                : Utf8JsonSerializer.PackAsync(value, stream, resolver ?? DefaultJsonFormatterResolver);

        public static Task<MemoryStream> PackAsync<T>(T value, IJsonFormatterResolver resolver = null) =>
            value is null
                ? Task.FromResult(new MemoryStream())
                : Utf8JsonSerializer.PackAsync(value, resolver ?? DefaultJsonFormatterResolver);

        public static Task PackAsync(object obj, Stream stream, IJsonFormatterResolver resolver = null) =>
            obj is null || stream is null
                ? Task.CompletedTask
                : Utf8JsonSerializer.PackAsync(obj, stream, resolver ?? DefaultJsonFormatterResolver);

        public static Task<MemoryStream> PackAsync(object obj, IJsonFormatterResolver resolver = null) =>
            obj is null
                ? Task.FromResult(new MemoryStream())
                : Utf8JsonSerializer.PackAsync(obj, resolver ?? DefaultJsonFormatterResolver);

        public static Task PackAsync(Type type, object obj, Stream stream, IJsonFormatterResolver resolver = null) =>
            obj is null || stream is null
                ? Task.CompletedTask
                : Utf8JsonSerializer.PackAsync(type, obj, stream, resolver ?? DefaultJsonFormatterResolver);

        public static Task<MemoryStream> PackAsync(Type type, object obj, IJsonFormatterResolver resolver = null) =>
            obj is null
                ? Task.FromResult(new MemoryStream())
                : Utf8JsonSerializer.PackAsync(type, obj, resolver ?? DefaultJsonFormatterResolver);

        public static Task<T> UnpackAsync<T>(Stream stream, IJsonFormatterResolver resolver = null) =>
            stream.IsNullOrEmpty()
                ? Task.FromResult((T)typeof(T).GetDefaultValue())
                : Utf8JsonSerializer.UnpackAsync<T>(stream, resolver ?? DefaultJsonFormatterResolver);

        public static Task<object> UnpackAsync(Type type, Stream stream, IJsonFormatterResolver resolver = null) =>
            stream.IsNullOrEmpty()
                ? Task.FromResult(type.GetDefaultValue())
                : Utf8JsonSerializer.UnpackAsync(type, stream, resolver ?? DefaultJsonFormatterResolver);
    }
}