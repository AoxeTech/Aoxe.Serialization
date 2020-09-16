using System;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonSerializer
    {
        public static string SerializeToJson(object obj, JsonSerializerSettings settings) =>
            JsonConvert.SerializeObject(obj, settings);

        public static T Deserialize<T>(string json, JsonSerializerSettings settings) =>
            JsonConvert.DeserializeObject<T>(json, settings);

        public static object Deserialize(Type type, string json, JsonSerializerSettings settings) =>
            JsonConvert.DeserializeObject(json, type, settings);
    }
}