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
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Stream Pack<TValue>(TValue value, JsonSerializerSettings settings, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(value, ms, settings, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Stream Pack(Type type, object? value, JsonSerializerSettings settings, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(type, value, ms, settings, encoding);
            return ms;
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="TValue"></typeparam>
        public static void Pack<TValue>(TValue value, Stream? stream, JsonSerializerSettings settings, Encoding encoding)
        {
            Serialize(value, settings, encoding).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Serialize the object to string, encode it to bytes and write to the stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        public static void Pack(Type type, object? value, Stream? stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            Serialize(type, value, settings, encoding).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue? Unpack<TValue>(Stream? stream, JsonSerializerSettings settings, Encoding encoding) =>
            (TValue) Unpack(typeof(TValue), stream, settings, encoding);

        /// <summary>
        /// Read the stream to bytes, encode it to string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static object? Unpack(Type type, Stream? stream, JsonSerializerSettings settings, Encoding encoding)
        {
            var result = Deserialize(type, encoding.GetString(stream.ReadToEnd()), settings);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}