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
        public static async Task<MemoryStream> PackAsync<T>(T t, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            t is null
                ? new MemoryStream()
                : await NewtonsoftJsonSerializer.PackAsync(t, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static async Task<MemoryStream> PackAsync(Type type, object obj, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            obj is null
                ? new MemoryStream()
                : await NewtonsoftJsonSerializer.PackAsync(type, obj, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static async Task PackAsync<T>(T t, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null)
        {
            if (t is null || stream is null) return;
            await NewtonsoftJsonSerializer.PackAsync(t, stream, settings ?? DefaultSettings,
                encoding ?? DefaultEncoding);
        }

        public static async Task PackAsync(Type type, object obj, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null)
        {
            if (obj is null || stream is null) return;
            await NewtonsoftJsonSerializer.PackAsync(type, obj, stream, settings ?? DefaultSettings,
                encoding ?? DefaultEncoding);
        }

        /// <summary>
        /// Asynchronously read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            stream is null
                ? (T) typeof(T).GetDefaultValue()
                : await NewtonsoftJsonSerializer.UnpackAsync<T>(stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        /// <summary>
        /// Asynchronously read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            stream is null
                ? type.GetDefaultValue()
                : await NewtonsoftJsonSerializer.UnpackAsync(type, stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);
    }
}