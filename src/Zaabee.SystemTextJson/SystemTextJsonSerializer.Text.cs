using System;
using System.Text.Json;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonSerializer
    {
        /// <summary>
        /// Convert the provided value into a <see cref="System.String"/>.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string SerializeToJson<T>(T o, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(o, options);

        /// <summary>
        /// Convert the provided value into a <see cref="System.String"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string SerializeToJson(Type type, object value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(value, type, options);

        /// <summary>
        /// Parse the text representing a single JSON value into a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="json"/> is null.
        /// </exception>
        /// <exception cref="JsonException">
        /// Thrown when the JSON is invalid,
        /// <typeparamref name="T"/> is not compatible with the JSON,
        /// or when there is remaining data in the Stream.
        /// </exception>
        public static T Deserialize<T>(string json, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize<T>(json, options);

        /// <summary>
        /// Parse the text representing a single JSON value into a <paramref name="type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="json"/> or <paramref name="type"/> is null.
        /// </exception>
        /// <exception cref="JsonException">
        /// Thrown when the JSON is invalid,
        /// the <paramref name="type"/> is not compatible with the JSON,
        /// or when there is remaining data in the Stream.
        /// </exception>
        public static object Deserialize(Type type, string json, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize(json, type, options);
    }
}