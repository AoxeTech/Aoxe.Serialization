using System;
using System.Text;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonSerializer
    {
        /// <summary>
        /// Serialize the object to json string and encode it into bytes used the encoding.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] Serialize<TValue>(TValue value, JsonSerializerSettings? settings, Encoding encoding) =>
            encoding.GetBytes(SerializeToJson(value, settings));

        /// <summary>
        /// Serialize the object to json string and encode it into bytes used the encoding.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] Serialize(Type type, object? value, JsonSerializerSettings? settings, Encoding encoding) =>
            encoding.GetBytes(SerializeToJson(type, value, settings));

        /// <summary>
        /// Use encoding to decode the bytes into string and deserialize it.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue? Deserialize<TValue>(byte[] bytes, JsonSerializerSettings? settings, Encoding encoding) =>
            (TValue) Deserialize(typeof(TValue), bytes, settings, encoding);

        /// <summary>
        /// Use encoding to decode the bytes into string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bytes"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static object? Deserialize(Type type, byte[] bytes, JsonSerializerSettings? settings, Encoding encoding) =>
            Deserialize(type, encoding.GetString(bytes), settings);
    }
}