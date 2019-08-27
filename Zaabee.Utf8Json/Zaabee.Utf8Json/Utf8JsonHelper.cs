﻿using System;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class Utf8JsonHelper
    {
        #region SerializeToString

        /// <summary>
        /// Serialize the object to json
        /// </summary>
        /// <param name="o">obj
        /// ect</param>
        /// <returns>json</returns>
        public static string SerializeToString<T>(T o) =>
            JsonSerializer.ToJsonString(o);

        /// <summary>
        /// Serialize to JsonString.
        /// </summary>
        public static string SerializeToString(object value) =>
            JsonSerializer.NonGeneric.ToJsonString(value);

        /// <summary>
        /// Serialize to JsonString.
        /// </summary>
        public static string SerializeToString(Type type, object value) =>
            JsonSerializer.NonGeneric.ToJsonString(type, value);

        /// <summary>
        /// Serialize to JsonString with specified resolver.
        /// </summary>
        public static string SerializeToString(object value, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.ToJsonString(value, resolver);

        /// <summary>
        /// Serialize to JsonString with specified resolver.
        /// </summary>
        public static string SerializeToString(Type type, object value, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.ToJsonString(type, value, resolver);

        #endregion

        #region SerializeToBytes

        /// <summary>
        /// Serialize the object to byte[]
        /// </summary>
        /// <param name="o">obj
        /// ect</param>
        /// <returns>json</returns>
        public static byte[] SerializeToBytes<T>(T o) =>
            JsonSerializer.Serialize(o);

        /// <summary>
        /// Serialize to binary with default resolver.
        /// </summary>
        public static byte[] SerializeToBytes(object value) =>
            JsonSerializer.NonGeneric.Serialize(value);

        /// <summary>
        /// Serialize to binary with default resolver.
        /// </summary>
        public static byte[] SerializeToBytes(Type type, object value) =>
            JsonSerializer.NonGeneric.Serialize(type, value);

        /// <summary>
        /// Serialize to binary with specified resolver.
        /// </summary>
        public static byte[] SerializeToBytes(object value, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(value, resolver);

        /// <summary>
        /// Serialize to binary with specified resolver.
        /// </summary>
        public static byte[] SerializeToBytes(Type type, object value, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(type, value, resolver);

        #endregion

        #region DeserializeFromString

        /// <summary>
        /// Deserialize the json to the generic object(if the string is null or white space then return default(T))
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="json">json</param>
        /// <returns>generic object</returns>
        public static T Deserialize<T>(string json) =>
            string.IsNullOrWhiteSpace(json) ? default(T) : JsonSerializer.Deserialize<T>(json);

        public static object Deserialize(Type type, string json) =>
            string.IsNullOrWhiteSpace(json) ? null : JsonSerializer.NonGeneric.Deserialize(type, json);

        public static object Deserialize(Type type, string json, IJsonFormatterResolver resolver) =>
            string.IsNullOrWhiteSpace(json) ? null : JsonSerializer.NonGeneric.Deserialize(type, json, resolver);

        #endregion

        #region DeserializeFromBytes

        /// <summary>
        /// Deserialize the json to the generic object(if the string is null or white space then return default(T))
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="bytes">json</param>
        /// <returns>generic object</returns>
        public static T Deserialize<T>(byte[] bytes) =>
            bytes == null ? default(T) : JsonSerializer.Deserialize<T>(bytes);

        public static object Deserialize(Type type, byte[] bytes) =>
            bytes == null ? null : JsonSerializer.NonGeneric.Deserialize(type, bytes);

        public static object Deserialize(Type type, byte[] bytes, IJsonFormatterResolver resolver) =>
            bytes == null ? null : JsonSerializer.NonGeneric.Deserialize(type, bytes, resolver);

        #endregion
    }
}