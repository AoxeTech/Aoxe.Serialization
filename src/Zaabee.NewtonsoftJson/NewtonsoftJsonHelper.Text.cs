using System;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        public static string SerializeToJson<T>(T t, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.SerializeToJson(t, settings ?? DefaultSettings);

        public static string SerializeToJson(Type type, object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.SerializeToJson(type, obj, settings ?? DefaultSettings);

        public static T Deserialize<T>(string json, JsonSerializerSettings settings = null) =>
            json.IsNullOrWhiteSpace()
                ? (T) typeof(T).GetDefaultValue()
                : NewtonsoftJsonSerializer.Deserialize<T>(json, settings ?? DefaultSettings);

        public static object Deserialize(Type type, string json, JsonSerializerSettings settings = null) =>
            json.IsNullOrWhiteSpace()
                ? type.GetDefaultValue()
                : NewtonsoftJsonSerializer.Deserialize(type, json, settings ?? DefaultSettings);
    }
}