using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonSerializer
    {
        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MemoryStream Pack<T>(T t, JsonSerializerSettings settings, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(t, ms, settings, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static MemoryStream Pack(Type type, object obj, JsonSerializerSettings settings, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(type, obj, ms, settings, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T t, Stream stream, JsonSerializerSettings settings, Encoding encoding)
        {
            Serialize(t, settings, encoding).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        public static void Pack(Type type, object obj, Stream stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            Serialize(type, obj, settings, encoding).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream, JsonSerializerSettings settings, Encoding encoding) =>
            (T) Unpack(typeof(T), stream, settings, encoding);

        /// <summary>
        /// Read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static object Unpack(Type type, Stream stream, JsonSerializerSettings settings, Encoding encoding)
        {
            var result = Deserialize(type, encoding.GetString(stream.ReadToEnd()), settings);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}