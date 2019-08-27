using System;
using System.IO;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class ObjectExtension
    {
        #region Utf8JsonToString

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

        #endregion

        #region Utf8JsonToBytes

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

        #endregion

        #region Utf8JsonToStream

        /// <summary>
        /// Serialize the object to stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static void Utf8JsonToStream<T>(this T obj, Stream stream) =>
            Utf8JsonHelper.SerializeToStream<T>(stream, obj);

        /// <summary>
        /// Serialize to stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static void Utf8JsonToStream(this object obj, Type type, Stream stream) =>
            Utf8JsonHelper.SerializeToStream(type, stream, obj);

        /// <summary>
        /// Serialize to stream with specified resolver.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static void Utf8JsonToStream(this object obj, Stream stream, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.SerializeToStream(stream, obj, resolver);

        /// <summary>
        /// Serialize to stream with specified resolver.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static void Utf8JsonToStream(this object obj, Type type, Stream stream,
            IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.SerializeToStream(type, stream, obj, resolver);

        #endregion
    }
}