using System;
using Zaabee.Extensions;

namespace Zaabee.Protobuf
{
    public static partial class ProtobufSerializer
    {
        /// <summary>
        /// Serialize the object into bytes and convert it to a base64 string
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string SerializeToBase64<T>(T t) =>
            Serialize(t).ToBase64String();

        /// <summary>
        /// Serialize the object into bytes and convert it to a base64 string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToBase64(object obj) =>
            Serialize(obj).ToBase64String();

        /// <summary>
        /// Deserialize a base64 string to generic object.
        /// </summary>
        /// <param name="base64"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBase64<T>(string base64) =>
            Deserialize<T>(base64.FromBase64ToBytes());

        /// <summary>
        /// Deserialize a base64 string to object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static object DeserializeFromBase64(Type type, string base64) =>
            Deserialize(type, base64.FromBase64ToBytes());
    }
}