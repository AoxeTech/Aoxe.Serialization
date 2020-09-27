using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonSerializer
    {
        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<MemoryStream> PackAsync<T>(T t, JsonSerializerSettings settings,
            Encoding encoding)
        {
            var ms = new MemoryStream();
            await PackAsync(t, ms, settings, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<MemoryStream> PackAsync(Type type, object obj, JsonSerializerSettings settings,
            Encoding encoding)
        {
            var ms = new MemoryStream();
            await PackAsync(type, obj, ms, settings, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task PackAsync<T>(T t, Stream stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            await Serialize(t, settings, encoding).WriteToAsync(stream, CancellationToken.None);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task PackAsync(Type type, object obj, Stream stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            await Serialize(type, obj, settings, encoding).WriteToAsync(stream, CancellationToken.None);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerSettings settings, Encoding encoding) =>
            (T) await UnpackAsync(typeof(T), stream, settings, encoding);

        /// <summary>
        /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            var result = Deserialize(type, encoding.GetString(await stream.ReadToEndAsync()), settings);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}