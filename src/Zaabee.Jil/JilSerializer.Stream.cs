using System;
using System.IO;
using System.Text;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilSerializer
    {
        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MemoryStream Pack<T>(T t, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(t, ms, options, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T t, Stream stream, Options options, Encoding encoding)
        {
            Serialize(t, options, encoding).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static MemoryStream Pack(object obj, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(obj, ms, options, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        public static void Pack(object obj, Stream stream, Options options, Encoding encoding)
        {
            Serialize(obj, options, encoding).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream, Options options, Encoding encoding)
        {
            var result = Deserialize<T>(encoding.GetString(stream.ReadToEnd()), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        /// <summary>
        /// Read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static object Unpack(Type type, Stream stream, Options options, Encoding encoding)
        {
            var result = Deserialize(type, encoding.GetString(stream.ReadToEnd()), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}