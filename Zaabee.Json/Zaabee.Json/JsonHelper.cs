using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zaabee.Json
{
    /// <summary>
    /// Json Helper
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Serialize the object to json
        /// </summary>
        /// <param name="o">obj
        /// ect</param>
        /// <param name="serializeFields">serialize fields</param>
        /// <param name="toLowerCamel">is to lower camel</param>
        /// <param name="dateTimeFormat"></param>
        /// <returns>json</returns>
        public static string Serialize<T>(T o, IEnumerable<string> serializeFields = null,
            bool toLowerCamel = false, string dateTimeFormat = null)
        {
            var settings = new JsonSerializerSettings();
            if (serializeFields != null || toLowerCamel)
                settings.ContractResolver = new JsonContractResolver(serializeFields, toLowerCamel);
            if (!string.IsNullOrWhiteSpace(dateTimeFormat))
                settings.DateFormatString = dateTimeFormat;
            return JsonConvert.SerializeObject(o, settings);
        }

        /// <summary>
        /// Deserialize the json to the generic object(if the string is null or white space then return default(T))
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="json">json</param>
        /// <returns>generic object</returns>
        public static T Deserialize<T>(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Deserialize the json to the specify type(if the string is null or white space then return null)
        /// </summary>
        /// <param name="json">json</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type)
        {
            return string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject(json, type);
        }
    }
}