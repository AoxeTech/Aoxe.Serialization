using System;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonSerializer
    {
        public static string SerializeToJson<T>(T value, IJsonFormatterResolver resolver) =>
            JsonSerializer.ToJsonString(value, resolver);

        public static string SerializeToJson(object obj, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.ToJsonString(obj, resolver);

        public static string SerializeToJson(Type type, object obj, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.ToJsonString(type, obj, resolver);

        public static T Deserialize<T>(string json, IJsonFormatterResolver resolver) =>
            JsonSerializer.Deserialize<T>(json, resolver);

        public static object Deserialize(Type type, string json, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Deserialize(type, json, resolver);
    }
}