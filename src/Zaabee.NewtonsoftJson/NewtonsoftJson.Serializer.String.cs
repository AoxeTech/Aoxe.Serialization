using System;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonSerializer
    {
        /// <summary>
        /// Serializes the specified object to a JSON string using a type, formatting and <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string SerializeToJson<T>(T t, JsonSerializerSettings settings) =>
            JsonConvert.SerializeObject(t, typeof(T), settings);

        /// <summary>
        /// Serializes the specified object to a JSON string using a type, formatting and <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string SerializeToJson(Type type, object obj, JsonSerializerSettings settings) =>
            JsonConvert.SerializeObject(obj, type, settings);

        /// <summary>
        /// Deserializes the JSON to the specified .NET type using <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, JsonSerializerSettings settings) =>
            JsonConvert.DeserializeObject<T>(json, settings);

        /// <summary>
        /// Deserializes the JSON to the specified .NET type using <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, string json, JsonSerializerSettings settings) =>
            JsonConvert.DeserializeObject(json, type, settings);
    }
}