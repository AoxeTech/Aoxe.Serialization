using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilSerializer
    {
        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<MemoryStream> PackAsync<T>(T t, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            await PackAsync(t, ms, options, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task PackAsync<T>(T t, Stream stream, Options options, Encoding encoding)
        {
            await Serialize(t, options, encoding).WriteToAsync(stream, CancellationToken.None);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<MemoryStream> PackAsync(object obj, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            await PackAsync(obj, ms, options, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task PackAsync(object obj, Stream stream, Options options, Encoding encoding)
        {
            await Serialize(obj, options, encoding).WriteToAsync(stream, CancellationToken.None);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream, Options options, Encoding encoding)
        {
            var result = Deserialize<T>(encoding.GetString(await stream.ReadToEndAsync()), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        /// <summary>
        /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Type type, Stream stream, Options options, Encoding encoding)
        {
            var result = Deserialize(type, encoding.GetString(await stream.ReadToEndAsync()), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}