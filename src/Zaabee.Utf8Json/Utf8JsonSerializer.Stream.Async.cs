using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;
using Zaabee.Extensions;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonSerializer
    {
        public static async Task PackAsync<T>(T value, Stream stream, IJsonFormatterResolver resolver)
        {
            await JsonSerializer.SerializeAsync(stream, value, resolver);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<MemoryStream> PackAsync<T>(T value, IJsonFormatterResolver resolver)
        {
            var ms = new MemoryStream();
            await PackAsync(value, ms, resolver);
            return ms;
        }

        public static async Task PackAsync(object obj, Stream stream, IJsonFormatterResolver resolver)
        {
            await JsonSerializer.NonGeneric.SerializeAsync(stream, obj, resolver);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<MemoryStream> PackAsync(object obj, IJsonFormatterResolver resolver)
        {
            var ms = new MemoryStream();
            await PackAsync(obj, ms, resolver);
            return ms;
        }

        public static async Task PackAsync(Type type, object obj, Stream stream, IJsonFormatterResolver resolver)
        {
            await JsonSerializer.NonGeneric.SerializeAsync(type, stream, obj, resolver);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<MemoryStream> PackAsync(Type type, object obj, IJsonFormatterResolver resolver)
        {
            var ms = new MemoryStream();
            await PackAsync(type, obj, ms, resolver);
            return ms;
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, IJsonFormatterResolver resolver)
        {
            var result = await JsonSerializer.DeserializeAsync<T>(stream, resolver);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream, IJsonFormatterResolver resolver)
        {
            var result = await JsonSerializer.NonGeneric.DeserializeAsync(type, stream, resolver);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}