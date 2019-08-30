using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class NewtonsoftJsonHelper
    {
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

        public static T Deserialize<T>(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }

        public static object Deserialize(string json, Type type)
        {
            return string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject(json, type);
        }
    }
}