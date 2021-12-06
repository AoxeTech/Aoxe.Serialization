using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        public static Task<MemoryStream> PackAsync<TValue>(TValue value, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            value is null
                ? Task.FromResult(new MemoryStream())
                : NewtonsoftJsonSerializer.PackAsync(value, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static Task<MemoryStream> PackAsync(Type type, object? value, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            value is null
                ? Task.FromResult(new MemoryStream())
                : NewtonsoftJsonSerializer.PackAsync(type, value, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static Task PackAsync<TValue>(TValue value, Stream? stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            value is null || stream is null
                ? Task.CompletedTask
                : NewtonsoftJsonSerializer.PackAsync(value, stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static Task PackAsync(Type type, object? value, Stream? stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            value is null || stream is null
                ? Task.CompletedTask
                : NewtonsoftJsonSerializer.PackAsync(type, value, stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        /// <summary>
        /// Asynchronously read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Task<TValue> UnpackAsync<TValue>(Stream? stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            stream.IsNullOrEmpty()
                ? Task.FromResult(default(TValue))
                : NewtonsoftJsonSerializer.UnpackAsync<TValue>(stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        /// <summary>
        /// Asynchronously read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Task<object> UnpackAsync(Type type, Stream? stream, JsonSerializerSettings? settings = null,
            Encoding? encoding = null) =>
            stream.IsNullOrEmpty()
                ? Task.FromResult<object?>(default)
                : NewtonsoftJsonSerializer.UnpackAsync(type, stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);
    }
}