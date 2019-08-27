using System;
using System.IO;
using Jil;

namespace Zaabee.Jil
{
    public static class JilHelper
    {
        /// <summary>
        /// Serialize the object to json
        /// </summary>
        /// <param name="o">obj
        /// ect</param>
        /// <param name="options"></param>
        /// <returns>json</returns>
        public static string Serialize<T>(T o, Options options = null) =>
            JSON.Serialize(o, options);

        /// <summary>
        /// Deserialize the json to the generic object(if the string is null or white space then return default(T))
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="json">json</param>
        /// <param name="options"></param>
        /// <returns>generic object</returns>
        public static T Deserialize<T>(string json, Options options = null) =>
            string.IsNullOrWhiteSpace(json) ? default(T) : JSON.Deserialize<T>(json, options);

        /// <summary>
        /// Deserialize the json to the specify type(if the string is null or white space then return null)
        /// </summary>
        /// <param name="json">json</param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, Options options = null)
        {
            if (string.IsNullOrWhiteSpace(json)) return null;
            using (var reader = new StringReader(json))
                return Deserialize(reader, type, options);
        }

        /// <summary>
        /// Deserialize the textReader to the specify type(if the textReader is null then return null)
        /// </summary>
        /// <param name="reader">json</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T Deserialize<T>(TextReader reader, Options options = null) =>
            reader == null ? default(T) : JSON.Deserialize<T>(reader, options);

        /// <summary>
        /// Deserialize the textReader to the specify type(if the textReader is null then return null)
        /// </summary>
        /// <param name="reader">json</param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object Deserialize(TextReader reader, Type type, Options options = null) =>
            reader == null ? null : JSON.Deserialize(reader, type, options);
    }
}