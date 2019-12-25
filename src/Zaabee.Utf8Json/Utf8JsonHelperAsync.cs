using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonHelper
    {
        public static async Task PackAsync<T>(T value, Stream stream, IJsonFormatterResolver resolver = null) =>
            await JsonSerializer.SerializeAsync(stream, value, resolver);

        public static async Task PackAsync(object value, Stream stream, IJsonFormatterResolver resolver = null) =>
            await JsonSerializer.NonGeneric.SerializeAsync(stream, value, resolver);

        public static async Task PackAsync(Type type, object value, Stream stream,
            IJsonFormatterResolver resolver = null) =>
            await JsonSerializer.NonGeneric.SerializeAsync(type, stream, value, resolver);

        public static async Task<T> UnpackAsync<T>(Stream stream, IJsonFormatterResolver resolver = null) =>
            await JsonSerializer.DeserializeAsync<T>(stream, resolver);

        public static async Task<object>
            UnpackAsync(Type type, Stream stream, IJsonFormatterResolver resolver = null) =>
            await JsonSerializer.NonGeneric.DeserializeAsync(type, stream, resolver);
    }
}