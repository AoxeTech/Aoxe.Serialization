using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Zaabee.Extensions;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonSerializer
    {
        /// <summary>
        /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<MemoryStream> PackAsync<T>(T value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            await PackAsync(value, ms, options);
            return ms;
        }

        /// <summary>
        /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<MemoryStream> PackAsync(Type type, object value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            await PackAsync(type, value, ms, options);
            return ms;
        }

        /// <summary>
        /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task PackAsync<T>(T value, Stream stream, JsonSerializerOptions options)
        {
            await JsonSerializer.SerializeAsync(stream, value, options);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task PackAsync(Type type, object value, Stream stream, JsonSerializerOptions options)
        {
            await JsonSerializer.SerializeAsync(stream, value, type, options);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Asynchronously reads the UTF-8 encoded text representing a single JSON value into an instance of a type
        /// specified by a generic type parameter.
        /// The Stream will be try seek to beginning position.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerOptions options)
        {
            var result = await JsonSerializer.DeserializeAsync<T>(stream, options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        /// <summary>
        /// Asynchronously reads the UTF-8 encoded text representing a single JSON value into a <paramref name="type"/>.
        /// The Stream will be try seek to beginning position.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerOptions options)
        {
            var result = await JsonSerializer.DeserializeAsync(stream, type, options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}