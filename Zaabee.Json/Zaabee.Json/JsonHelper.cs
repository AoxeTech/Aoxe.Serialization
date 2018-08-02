using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zaabee.Json
{
    /// <summary>
    /// Json Helper
    /// </summary>
    public static class JsonHelper
    {
        private static readonly IsoDateTimeConverter Iso = new IsoDateTimeConverter
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
        };

        /// <summary>
        /// Serialize the object to json
        /// </summary>
        /// <param name="o">obj
        /// ect</param>
        /// <param name="serializeFields">serialize fields</param>
        /// <param name="toLowerCamel">is to lower camel</param>
        /// <returns>json</returns>
        internal static string Serialize<T>(T o, IEnumerable<string> serializeFields = null,
            bool toLowerCamel = false)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(Iso);
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            if (serializeFields != null || toLowerCamel)
                settings.ContractResolver = new JsonContractResolver(serializeFields, toLowerCamel);
            return JsonConvert.SerializeObject(o, settings);
        }

        /// <summary>
        /// Deserialize the json to the generic object(if the string is null or white space then return default(T))
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="json">json</param>
        /// <returns>generic object</returns>
        internal static T Deserialize<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return default(T);
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            });
        }

        /// <summary>
        /// Deserialize the json to the specify type(if the string is null or white space then return null)
        /// </summary>
        /// <param name="json">json</param>
        /// <param name="type"></param>
        /// <returns>generic object</returns>
        internal static object Deserialize(string json, Type type)
        {
            if (string.IsNullOrWhiteSpace(json)) return null;
            return JsonConvert.DeserializeObject(json, type, new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            });
        }
    }
}