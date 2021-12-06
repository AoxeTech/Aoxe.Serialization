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
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static async Task<MemoryStream> PackAsync<TValue>(TValue value, JsonSerializerSettings settings,
            Encoding encoding)
        {
            var ms = new MemoryStream();
            await PackAsync(value, ms, settings, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<MemoryStream> PackAsync(Type type, object? value, JsonSerializerSettings settings,
            Encoding encoding)
        {
            var ms = new MemoryStream();
            await PackAsync(type, value, ms, settings, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static async Task PackAsync<TValue>(TValue value, Stream? stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            await Serialize(value, settings, encoding).WriteToAsync(stream, CancellationToken.None);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task PackAsync(Type type, object? value, Stream? stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            await Serialize(type, value, settings, encoding).WriteToAsync(stream, CancellationToken.None);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static async Task<TValue> UnpackAsync<TValue>(Stream? stream, JsonSerializerSettings settings, Encoding encoding) =>
            (TValue) await UnpackAsync(typeof(TValue), stream, settings, encoding);

        /// <summary>
        /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Type type, Stream? stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            var result = Deserialize(type, encoding.GetString(await stream.ReadToEndAsync()), settings);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}