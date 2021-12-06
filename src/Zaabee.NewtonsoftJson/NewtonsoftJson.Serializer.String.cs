using System;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonSerializer
    {
        /// <summary>
        /// Serializes the specified object to a JSON string using a type, formatting and <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string SerializeToJson<TValue>(TValue value, JsonSerializerSettings settings) =>
            JsonConvert.SerializeObject(value, typeof(TValue), settings);

        /// <summary>
        /// Serializes the specified object to a JSON string using a type, formatting and <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string SerializeToJson(Type type, object? value, JsonSerializerSettings settings) =>
            JsonConvert.SerializeObject(value, type, settings);

        /// <summary>
        /// Deserializes the JSON to the specified .NET type using <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue? Deserialize<TValue>(string json, JsonSerializerSettings settings) =>
            JsonConvert.DeserializeObject<TValue>(json, settings);

        /// <summary>
        /// Deserializes the JSON to the specified .NET type using <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static object? Deserialize(Type type, string json, JsonSerializerSettings settings) =>
            JsonConvert.DeserializeObject(json, type, settings);
    }
}