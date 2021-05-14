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
        /// <param name="t"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] Serialize<T>(T t, JsonSerializerSettings settings, Encoding encoding) =>
            encoding.GetBytes(SerializeToJson(t, settings));

        /// <summary>
        /// Serialize the object to json string and encode it into bytes used the encoding.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] Serialize(Type type, object obj, JsonSerializerSettings settings, Encoding encoding) =>
            encoding.GetBytes(SerializeToJson(type, obj, settings));

        /// <summary>
        /// Use encoding to decode the bytes into string and deserialize it.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] bytes, JsonSerializerSettings settings, Encoding encoding) =>
            (T) Deserialize(typeof(T), bytes, settings, encoding);

        /// <summary>
        /// Use encoding to decode the bytes into string and deserialize it.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bytes"></param>
        /// <param name="settings"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, byte[] bytes, JsonSerializerSettings settings, Encoding encoding) =>
            Deserialize(type, encoding.GetString(bytes), settings);
    }
}