using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class Utf8JsonHelper
    {
        /// <summary>
        /// Serialize the object to json
        /// </summary>
        /// <param name="o">obj
        /// ect</param>
        /// <returns>json</returns>
        public static string SerializeToString<T>(T o)
        {
            return JsonSerializer.ToJsonString(o);
        }

        /// <summary>
        /// Serialize the object to byte[]
        /// </summary>
        /// <param name="o">obj
        /// ect</param>
        /// <returns>json</returns>
        public static byte[] SerializeToByte<T>(T o)
        {
            return JsonSerializer.Serialize(o);
        }

        /// <summary>
        /// Deserialize the json to the generic object(if the string is null or white space then return default(T))
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="json">json</param>
        /// <returns>generic object</returns>
        public static T Deserialize<T>(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? default(T) : JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// Deserialize the json to the generic object(if the string is null or white space then return default(T))
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="bytes">json</param>
        /// <returns>generic object</returns>
        public static T Deserialize<T>(byte[] bytes)
        {
            return bytes == null ? default(T) : JsonSerializer.Deserialize<T>(bytes);
        }
    }
}