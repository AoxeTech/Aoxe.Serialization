using System;
using ZeroFormatter;

namespace Zaabee.ZeroFormatter
{
    public static partial class ZeroSerializer
    {
        /// <summary>
        /// Serializes the specified generic instance to a bytes.
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] Serialize<T>(T t) =>
            ZeroFormatterSerializer.Serialize(t);

        /// <summary>
        /// Serializes the specified object to a bytes.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Serialize(Type type, object obj) =>
            ZeroFormatterSerializer.NonGeneric.Serialize(type, obj);

        /// <summary>
        /// Deserializes the bytes to an generic instance.
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] bytes) =>
            ZeroFormatterSerializer.Deserialize<T>(bytes);

        /// <summary>
        /// Deserializes the bytes to an object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, byte[] bytes) =>
            ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes);
    }
}