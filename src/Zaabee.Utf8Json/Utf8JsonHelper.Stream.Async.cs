using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;
using Zaabee.Extensions;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonHelper
    {
        public static async Task PackAsync<T>(T value, Stream stream, IJsonFormatterResolver resolver = null)
        {
            if (value is null || stream is null) return;
            await Utf8JsonSerializer.PackAsync(value, stream, resolver ?? DefaultJsonFormatterResolver);
        }

        public static async Task<MemoryStream> PackAsync<T>(T value, IJsonFormatterResolver resolver = null) =>
            value is null
                ? new MemoryStream()
                : await Utf8JsonSerializer.PackAsync(value, resolver ?? DefaultJsonFormatterResolver);

        public static async Task PackAsync(object obj, Stream stream, IJsonFormatterResolver resolver = null)
        {
            if (obj is null || stream is null) return;
            await Utf8JsonSerializer.PackAsync(obj, stream, resolver ?? DefaultJsonFormatterResolver);
        }

        public static async Task<MemoryStream> PackAsync(object obj, IJsonFormatterResolver resolver = null) =>
            obj is null
                ? new MemoryStream()
                : await Utf8JsonSerializer.PackAsync(obj, resolver ?? DefaultJsonFormatterResolver);

        public static async Task PackAsync(Type type, object obj, Stream stream, IJsonFormatterResolver resolver = null)
        {
            if (obj is null || stream is null) return;
            await Utf8JsonSerializer.PackAsync(type, obj, stream, resolver ?? DefaultJsonFormatterResolver);
        }

        public static async Task<MemoryStream> PackAsync(Type type, object obj,
            IJsonFormatterResolver resolver = null) =>
            obj is null
                ? new MemoryStream()
                : await Utf8JsonSerializer.PackAsync(type, obj, resolver ?? DefaultJsonFormatterResolver);

        public static async Task<T> UnpackAsync<T>(Stream stream, IJsonFormatterResolver resolver = null) =>
            stream.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : await Utf8JsonSerializer.UnpackAsync<T>(stream, resolver ?? DefaultJsonFormatterResolver);

        public static async Task<object> UnpackAsync(Type type, Stream stream,
            IJsonFormatterResolver resolver = null) =>
            stream.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : await Utf8JsonSerializer.UnpackAsync(type, stream, resolver ?? DefaultJsonFormatterResolver);
    }
}