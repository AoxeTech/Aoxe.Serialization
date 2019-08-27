using System;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Utf8JsonToString<T>(this T obj) =>
            Utf8JsonHelper.SerializeToString(obj);

        /// <summary>
        /// Serialize to JsonString.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string Utf8JsonToString(this object obj, Type type) =>
            Utf8JsonHelper.SerializeToString(type, obj);

        /// <summary>
        /// Serialize to JsonString with specified resolver.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static string Utf8JsonToString(this object obj, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.SerializeToString(obj, resolver);

        /// <summary>
        /// Serialize to JsonString with specified resolver.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static string Utf8JsonToString(this object obj, Type type, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.SerializeToString(type, obj, resolver);

        /// <summary>
        /// Serialize the object to byte[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Utf8JsonToBytes<T>(this T obj) =>
            Utf8JsonHelper.SerializeToBytes(obj);

        /// <summary>
        /// Serialize to byte[].
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] Utf8JsonToBytes(this object obj, Type type) =>
            Utf8JsonHelper.SerializeToBytes(type, obj);

        /// <summary>
        /// Serialize to byte[] with specified resolver.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static byte[] Utf8JsonToBytes(this object obj, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.SerializeToBytes(obj, resolver);

        /// <summary>
        /// Serialize to byte[] with specified resolver.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static byte[] Utf8JsonToBytes(this object obj, Type type, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.SerializeToBytes(type, obj, resolver);
    }
}