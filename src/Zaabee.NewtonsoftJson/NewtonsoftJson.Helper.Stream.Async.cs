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
        public static Task<MemoryStream> PackAsync<T>(T t, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            t is null
                ? Task.FromResult(new MemoryStream())
                : NewtonsoftJsonSerializer.PackAsync(t, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static Task<MemoryStream> PackAsync(Type type, object obj, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            obj is null
                ? Task.FromResult(new MemoryStream())
                : NewtonsoftJsonSerializer.PackAsync(type, obj, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static Task PackAsync<T>(T t, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            t is null || stream is null
                ? Task.CompletedTask
                : NewtonsoftJsonSerializer.PackAsync(t, stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static Task PackAsync(Type type, object obj, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            obj is null || stream is null
                ? Task.CompletedTask
                : NewtonsoftJsonSerializer.PackAsync(type, obj, stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        /// <summary>
        /// Asynchronously read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> UnpackAsync<T>(Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            stream.IsNullOrEmpty()
                ? Task.FromResult((T)typeof(T).GetDefaultValue())
                : NewtonsoftJsonSerializer.UnpackAsync<T>(stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        /// <summary>
        /// Asynchronously read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            stream.IsNullOrEmpty()
                ? Task.FromResult(type.GetDefaultValue())
                : NewtonsoftJsonSerializer.UnpackAsync(type, stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);
    }
}