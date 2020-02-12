using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonHelper
    {
        public static async Task PackAsync<T>(T value, Stream stream, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonSerializer.PackAsync(value, stream, resolver ?? DefaultJsonFormatterResolver);

        public static async Task PackAsync(object obj, Stream stream, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonSerializer.PackAsync(obj, stream, resolver ?? DefaultJsonFormatterResolver);

        public static async Task PackAsync(Type type, object obj, Stream stream, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonSerializer.PackAsync(type, obj, stream, resolver ?? DefaultJsonFormatterResolver);

        public static async Task<T> UnpackAsync<T>(Stream stream, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonSerializer.UnpackAsync<T>(stream, resolver ?? DefaultJsonFormatterResolver);

        public static async Task<object> UnpackAsync(Type type, Stream stream, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonSerializer.UnpackAsync(type, stream, resolver ?? DefaultJsonFormatterResolver);
    }
}